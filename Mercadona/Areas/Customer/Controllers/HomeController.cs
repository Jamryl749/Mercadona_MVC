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
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return View(catalogueViewModel);
        }
        public PartialViewResult GetProducts()
        {
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            return PartialView("_Catalogue", catalogueViewModel);
        }
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}