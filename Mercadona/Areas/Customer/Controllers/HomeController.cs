/**
 *@file HomeController.cs
 *brief Controller for the Home Page
*/
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mercadona.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /**
         * @fn Index()
         * @return a View Index.cshtml
         * @brief Return the view Index page for the HomeController.
         * @details In this case it displays a catalogue of all products.
        */
        public IActionResult Index()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return View(catalogueViewModel);
        }
        /**
         * @fn GetProducts()
         * @return a PartialView _Catalogue.cshtml
         * @brief Return all the products from the database and displays them in _Catalogue.cshtml.
        */
        public PartialViewResult GetProducts()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return PartialView("_Catalogue", catalogueViewModel);
        }
        /**
         * @fn FilterDiscounted()
         * @return a PartialView _Catalogue.cshtml
         * @brief Return all the discounted products from the database and displays them in _Catalogue.cshtml.
        */
        public PartialViewResult FilterDiscounted(string categoryId)
        {
            var currentDate = DateTime.Now;
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel();
            if (categoryId == "all")
            {
                catalogueViewModel.Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").Where(
                    x => x.DiscountId != null &&
                    DateTime.Now.Ticks > x.Discount.StartDate.Ticks && x.Discount.EndDate != null && DateTime.Now.Ticks < x.Discount.EndDate.GetValueOrDefault().Ticks ||
                    x.Discount != null && DateTime.Now.Ticks > x.Discount.StartDate.Ticks && x.Discount.EndDate == null);
                catalogueViewModel.Categories = _unitOfWork.Category.GetAll();
            }
            else
            {
                catalogueViewModel.Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").Where(x => x.CategoryId.ToString() == categoryId &&
                    x.DiscountId != null && DateTime.Now.Ticks > x.Discount.StartDate.Ticks && x.Discount.EndDate != null && DateTime.Now.Ticks < x.Discount.EndDate.GetValueOrDefault().Ticks ||
                    x.CategoryId.ToString() == categoryId && x.Discount != null && DateTime.Now.Ticks > x.Discount.StartDate.Ticks && x.Discount.EndDate == null);
                catalogueViewModel.Categories = _unitOfWork.Category.GetAll();
            }
            return PartialView("_Catalogue", catalogueViewModel); 
        }
        /**
         * @fn FilterCategory()
         * @return a PartialView _Catalogue.cshtml
         * @brief Return all the products of a specific Category from the database and displays them in _Catalogue.cshtml.
        */
        public PartialViewResult FilterCategory(string categoryId)
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel();
            if (categoryId == "all")
            {
                catalogueViewModel.Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount");
                catalogueViewModel.Categories = _unitOfWork.Category.GetAll();
            }
            else
            {
                catalogueViewModel.Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount").Where(p => p.CategoryId.ToString() == categoryId);
                catalogueViewModel.Categories = _unitOfWork.Category.GetAll();
            }
            return PartialView("_Catalogue", catalogueViewModel);
        }
        /**
         * @fn Privacy()
         * @return a View Privacy.cshtml
         * @brief Return the view Privacy page for the HomeController.
        */
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        /**
         * @fn Error()
         * @return a View Error.cshtml
        */
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}