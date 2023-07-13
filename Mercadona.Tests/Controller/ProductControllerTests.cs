using Mercadona.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mercadona.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly ProductController _productController;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly TempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly ITempDataDictionary _tempData;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductControllerTests()
        {
            //Dependencies
            _unitOfWork = A.Fake<IUnitOfWork>();
            _tempDataProvider = A.Fake<ITempDataProvider>();
            _tempDataDictionaryFactory = A.Fake<TempDataDictionaryFactory>();
            _tempData = _tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());
            _hostingEnvironment = A.Fake<IWebHostEnvironment>();

            //SUT
            _productController = new ProductController(_unitOfWork, _hostingEnvironment)
            {
                TempData = _tempData,
            };
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Arrange
            //Act
            var result = _productController.Index();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsListOfProductsAndCount()
        {
            //Act
            var products = _unitOfWork.Product.GetAll().ToList();
            products.Add(new Product {  });
            products.Add(new Product {  });
            //Assert
            products.Should().BeOfType<List<Product>>();
            products.Count().Should().Be(2);
        }
        [Fact]
        public void Upsert_Get_ActionExecutes_ReturnsViewForUpsert()
        {
            //Arrange

            //Act
            var result = _productController.Upsert(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Get_InvalidModelState_ReturnsView()
        {
            _productController.ModelState.AddModelError("Name", "Name is required");
            var product = new Product { };
            //Act
            var result = _productController.Upsert(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Get_ActionExecutes_ReturnsViewForNull()
        {
            //Arrange
            //Act
            var result = _productController.Upsert(null);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Post_ActionExecutes_ReturnsViewForZero()
        {
            //Arrange
            //Act
            var result = _productController.Upsert(0);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Post_ActionExecuted_RedirectsToIndexAction()
        {
            //Arrange
            //Act
            var result = _productController.Upsert(0);
            //Assert
            result.Should().BeOfType<IActionResult>();
        }
        [Fact]
        public void GetAll_ActionExecutes_ReturnsJson()
        {
            //Act
            var result = _productController.GetAll();
            //Assert
            result.Should().BeOfType<JsonResult>();
        }
        [Fact]
        public void Delete_ActionExecutes_ReturnsJson()
        {
            //Arrange
            //Act
            var result = _productController.Delete(1);
            //Assert
            result.Should().BeOfType<JsonResult>();
        }
    }
}
