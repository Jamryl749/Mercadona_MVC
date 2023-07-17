using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Mercadona.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DiscountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return View(objDiscountList);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Discount discount = new Discount();

            if (id == null || id == 0)
            {
                //create
                return View(discount);
            }
            else
            {
                //update
                discount = _unitOfWork.Discount.Get(x => x.Id == id);
                return View(discount);
            }
        }
        [HttpPost, ActionName("Upsert")]
        public IActionResult UpsertPost(Discount discount)
        {
            if (ModelState.IsValid)
            {
                if (discount.Id == 0)
                {
                    _unitOfWork.Discount.Add(discount);
                }
                else
                {
                    var productList = _unitOfWork.Product.GetAll().Where(x => x.DiscountId == discount.Id).ToList();
                    if (productList.Count > 0)
                    {
                        foreach (Product product in productList)
                        {
                            //update new discounted price
                            decimal percentage = (decimal)discount.DiscountValue / 100m;
                            decimal reduction = 1m - percentage;
                            decimal grossDiscountedPrice = product.Price * reduction;
                            product.DiscountedPrice = Math.Round(grossDiscountedPrice, 2, MidpointRounding.ToEven);
                            _unitOfWork.Product.Update(product);
                        }
                    }
                    _unitOfWork.Discount.Update(discount);
                }

                _unitOfWork.Save();
                TempData["success"] = "Discount created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return Json(new { data = objDiscountList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var discountToBeDeleted = _unitOfWork.Discount.Get(x => x.Id == id);
            if (discountToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Discount.Remove(discountToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Discount deleted successfully" });
        }

        #endregion
    }
}
