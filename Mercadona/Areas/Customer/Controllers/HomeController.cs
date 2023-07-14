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