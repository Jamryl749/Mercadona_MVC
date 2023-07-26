/**
 *@file HomeController.cs
 *brief Controller for the Home Page
*/
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/// <summary>
/// Namespace for Mercadona.Areas.Customer.Controllers.
/// </summary>
namespace Mercadona.Areas.Customer.Controllers
{
    /// <summary>
    /// Defines a HomeController within the Customer Area.
    /// </summary>
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor for HomeController, takes an IUnitOfWork object as a parameter.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work pattern interface for the repositories.</param>
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Action for displaying the home page (Index view).
        /// </summary>
        /// <returns>A ViewResult object representing the index view for the HomeController.</returns>
        public IActionResult Index()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return View(catalogueViewModel);
        }

        /// <summary>
        /// Retrieves all products from the database and displays them in a partial view.
        /// </summary>
        /// <returns>A PartialViewResult object that renders the _Catalogue partial view.</returns>
        public PartialViewResult GetProducts()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return PartialView("_Catalogue", catalogueViewModel);
        }

        /// <summary>
        /// Retrieves all discounted products from the database and displays them in a partial view.
        /// </summary>
        /// <param name="categoryId">Id of the category to filter by.</param>
        /// <returns>A PartialViewResult object that renders the _Catalogue partial view.</returns>
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

        /// <summary>
        /// Retrieves all the products of a specific Category from the database and displays them in a partial view.
        /// </summary>
        /// <param name="categoryId">Id of the category to filter by.</param>
        /// <returns>A PartialViewResult object that renders the _Catalogue partial view.</returns>
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

        /// <summary>
        /// Action for displaying the privacy page (Privacy view).
        /// </summary>
        /// <returns>A ViewResult object representing the privacy view for the HomeController.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        /// <summary>
        /// Action for displaying the error page (Error view).
        /// </summary>
        /// <returns>A ViewResult object representing the error view for the HomeController.</returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}