using Mercadona.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mercadona.Tests.Controller
{
    public class ProductControllerTests
    {
        private readonly ProductController _productController;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly ITempDataDictionary _tempData;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ProductControllerTests()
        {
            //Dependencies
            _unitOfWork = A.Fake<IUnitOfWork>();
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
            products.Add(new Product { });
            products.Add(new Product { });
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
        public void Upsert_Get_ActionExecutes_ReturnsViewForZero()
        {
            //Arrange
            //Act
            var result = _productController.Upsert(0);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Post_ActionExecutes_RedirectsToIndexAction()
        {
            //Arrange
            var product = new Product { };
            var categoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var discountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var productViewModel = new ProductViewModel { Product = product, CategoryList = categoryList, DiscountList = discountList };
            //Act
            var result = _productController.Upsert(productViewModel, null);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void Upsert_Post_InvalidModelState_ReturnsView()
        {
            _productController.ModelState.AddModelError("Name", "Name is required");
            var iFormFile = A.Fake<IFormFile>();
            var product = new Product { };
            var categoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var discountList = _unitOfWork.Discount.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            var productViewModel = new ProductViewModel { Product = product, CategoryList = categoryList, DiscountList = discountList };
            //Act
            var result = _productController.Upsert(productViewModel, iFormFile);
            //Assert
            result.Should().BeOfType<ViewResult>();
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
        [Fact]
        public void GetDiscountData_ActionExecutes_ReturnJson()
        {
            var result = _productController.GetDiscountData(1);

            result.Should().BeOfType<JsonResult>();
        }
    }
}
