/**
 *@file ProductController.cs
 *@brief Controller for the Product Entities
 *@details It determines what response to send back to a user when a user makes a browser request concerning a product.
*/
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Mercadona.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        /**
         * @fn Index()
         * @return Product/Index.cshtml
         * @brief Return (Read and Show) the Index page for the Product entities.
         * @details In this case it shows all the products present on the database as a list. From there you can perform CRUD (Create, Read(Show), Update, Delete) on products.
        */
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").ToList();
            return View(objProductList);
        }

        /**
         * @fn Upsert()
         * @param id an int
         * @return Product/Upsert.cshtml
         * @brief Return the page for the creation/edition of Product entities.
        */
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductViewModel productViewModel = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productViewModel);
            }
            else
            {
                //update
                productViewModel.Product = _unitOfWork.Product.Get(x => x.Id == id);
                return View(productViewModel);
            }
        }

        /**
         * @fn UpsertPost()
         * @param productViewModel is a ProductViewModel class element
         * @param file is a IFormFile interface
         * @return Product/Index.cshtml if the ModelState is valid
         * @return Product/Upsert.cshtml if the ModelState is not valid
         * @brief Create or Edit a product.
         * @details if (ModelState.IsValid)
         * @details Create or replace the product image, Uses Add() function from the IRepository to add the new product to the database. Then Save() function from the IUnitOfWork interface to save the database. Return the Index page to show the list of all the products
         * @details else
         * GetAll() the existing products that have the product and update them. Uses the Update() function from the IRepository interface to update the product. Then Save() function from the IUnitOfWork interface to save the database and redirect to the Index page.
        */
        [HttpPost, ActionName("Upsert")]
        public IActionResult UpsertPost(ProductViewModel productViewModel, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"img\product");

                    if (!string.IsNullOrEmpty(productViewModel.Product.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, productViewModel.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    productViewModel.Product.ImageUrl = @"\img\product\" + filename;

                }

                if (productViewModel.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productViewModel.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productViewModel.Product);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                productViewModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                productViewModel.DiscountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });

                return View(productViewModel);
            }
        }

        /**
         * @fn GetDiscountData()
         * @return a discount as Json
         * @brief Return a Discount entities as a Json.
        */
        [HttpPost]
        public ActionResult GetDiscountData(int? pId)
        {
            var discount = _unitOfWork.Discount.Get(x => x.Id == pId);
            if (discount != null)
            {
                discount.StartDate.ToString("yyyy-MM-dd");
                discount.EndDate.GetValueOrDefault().ToString("yyyy-MM-dd");
                return Json(discount);
            }
            else
            {
                return Json(null);
            }
        }

        #region API CALLS
        /**
         * @fn GetAll()
         * @return A list of products as Json
         * @brief Return a list of Products entities as a Json.
        */
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").ToList();
            return Json(new { data = objProductList });
        }

        /**
         * @fn Delete()
         * @param id an int
         * @return a fail Json message if the product retreived from the id is null
         * @return a success Json message if the product exist
         * @brief Return the Product Index page after the delete of an existing Product entitiy.
         * @details if productToBeDeleted != null
         * @details We use the Remove() function from the IRepository to delete the product from the database. Then we use the Save() function from the IUnitOfWork interface to save the database and finally we return a success Json mesage
         * @details else
         * @details return a fail Json message if the product retreived from the id is null
        */
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(x => x.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (productToBeDeleted.ImageUrl != null)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

            }
            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Product deleted successfully" });
        }

        #endregion
    }
}
