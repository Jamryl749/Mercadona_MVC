using Mercadona.Areas.Customer.Controllers;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace Mercadona.Tests.Controller
{
    public class HomeControllerTests
    {
        private readonly HomeController _homeController;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeControllerTests()
        {
            //Dependencies
            _logger = A.Fake<ILogger<HomeController>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            _homeController = new HomeController(_unitOfWork);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Arrange
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            //Act
            var result = _homeController.Index();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void GetProduct_ActionExecutes_ReturnsPartialViewForCatalogue()
        {
            //Arrange
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            //Act
            var result = _homeController.GetProducts();
            //Assert
            result.Should().BeOfType<PartialViewResult>();
        }
        [Fact]
        public void FilterDiscounted_ActionExecutes_ReturnsPartialViewForCatalogue()
        {
            //Arrange
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            //Act
            var result = _homeController.FilterDiscounted("all");
            //Assert
            result.Should().BeOfType<PartialViewResult>();
        }
        [Fact]
        public void FilterCategory_ActionExecutes_ReturnsPartialViewForCatalogue()
        {
            //Arrange
            CatalogueViewModel catalogueViewModel = new CatalogueViewModel()
            {
                Products = _unitOfWork.Product.GetAll(includeCategories: "Category", includeDiscounts: "Discount"),
                Categories = _unitOfWork.Category.GetAll()
            };
            //Act
            var result = _homeController.FilterCategory("2");
            //Assert
            result.Should().BeOfType<PartialViewResult>();
        }
        [Fact]
        public void Privacy_ActionExecutes_ReturnsViewForPrivacy()
        {
            //Act
            var result = _homeController.Privacy();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
    }
}
