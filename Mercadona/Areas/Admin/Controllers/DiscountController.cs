using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

/// <summary>
/// Handles the functionality related to discounts, including viewing, creating, editing, and deleting discounts.
/// </summary>
namespace Mercadona.Areas.Admin.Controllers
{
    /// <summary>
    /// DiscountController is responsible for handling CRUD operations for discounts.
    /// </summary>
    /// <remarks>
    /// This controller is decorated with the Authorize attribute, allowing only users with the "Admin" role to use its methods.
    /// </remarks>
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DiscountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the DiscountController class.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work pattern, used for manipulating database records.</param>
        public DiscountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Lists all discounts.
        /// </summary>
        /// <returns>View displaying the list of discounts.</returns>
        public IActionResult Index()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return View(objDiscountList);
        }

        /// <summary>
        /// Prepares the form for creating a new discount or updating an existing one.
        /// </summary>
        /// <param name="id">ID of the discount, if null or 0 a new discount will be created.</param>
        /// <returns>View displaying the form for creating or updating a discount.</returns>
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

        /// <summary>
        /// Handles the submission of a form for creating or updating a discount.
        /// </summary>
        /// <param name="discount">Discount to be created or updated.</param>
        /// <returns>Redirects to index action after successful creation/update, otherwise returns the same view for displaying validation errors.</returns>
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

        /// <summary>
        /// Lists all discounts as a JSON response.
        /// </summary>
        /// <returns>JSON response containing all discounts.</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return Json(new { data = objDiscountList });
        }

        /// <summary>
        /// Deletes a discount with the specified id.
        /// </summary>
        /// <param name="id">ID of the discount to be deleted.</param>
        /// <returns>JSON response containing the result of the deletion operation.</returns>
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
