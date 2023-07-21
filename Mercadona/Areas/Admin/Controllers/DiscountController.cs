/**
 *@file DiscountController.cs
 *@brief Controller for the Discount Entities
 *@details It determines what response to send back to a user when a user makes a browser request concerning a discount.
*/
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
        /**
         * @fn Index()
         * @return Discount/Index.cshtml
         * @brief Return (Read and Show) the Index page for the Discount entities.
         * @details In this case it shows all the discounts present on the database as a list. From there you can perform CRUD (Create, Read(Show), Update, Delete) on discounts.
        */
        public IActionResult Index()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return View(objDiscountList);
        }
        /**
         * @fn Upsert()
         * @param id an int
         * @return Discount/Upsert.cshtml
         * @brief Return the page for the creation/edition of Discount entities.
        */
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
        /**
         * @fn UpsertPost()
         * @param discount is a new Discount class element
         * @return Discount/Index.cshtml if the ModelState is valid
         * @return Discount/Upsert.cshtml if the ModelState is not valid
         * @brief Create or Edit a discount.
         * @details if (ModelState.IsValid && discount.Id == 0) (new discount)
         * @details Uses Add() function from the IRepository to add the new discount to the database. Then Save() function from the IUnitOfWork interface to save the database. Return the Index page to show the list of all the discounts
         * @details else
         * GetAll() the existing products that have the discount and update them. Uses the Update() function from the IRepository interface to update the discount. Then Save() function from the IUnitOfWork interface to save the database and redirect to the Index page.
        */
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
        /**
         * @fn GetAll()
         * @return A list on discounts as Json
         * @brief Return a list of Discount entities as a Json.
        */
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Discount> objDiscountList = _unitOfWork.Discount.GetAll().ToList();
            return Json(new { data = objDiscountList });
        }
        /**
         * @fn Delete()
         * @param id an int
         * @return a fail Json message if the discount retreived from the id is null
         * @return a success Json message if the discount exist
         * @brief Return the Discount Index page after the delete of an existing Discount entitiy.
         * @details if discountToBeDeleted != null
         * @details We use the Remove() function from the IRepository to delete the discount from the database. Then we use the Save() function from the IUnitOfWork interface to save the database and finally we return a success Json mesage
         * @details else
         * @details return a fail Json message if the discount retreived from the id is null
        */
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
