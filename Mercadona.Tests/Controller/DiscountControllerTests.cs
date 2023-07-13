using Mercadona.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mercadona.Tests.Controller
{
    public class DiscountControllerTests
    {
        private readonly DiscountController _discountController;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly TempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly ITempDataDictionary _tempData;

        public DiscountControllerTests()
        {
            //Dependencies
            _unitOfWork = A.Fake<IUnitOfWork>();
            _tempDataProvider = A.Fake<ITempDataProvider>();
            _tempDataDictionaryFactory = A.Fake<TempDataDictionaryFactory>();
            _tempData = _tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            //SUT
            _discountController = new DiscountController(_unitOfWork)
            {
                TempData = _tempData,
            };
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Arrange
            //Act
            var result = _discountController.Index();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsListOfDiscountsAndCount()
        {
            //Act
            var discounts = _unitOfWork.Discount.GetAll().ToList();
            discounts.Add(new Discount { });
            discounts.Add(new Discount { });
            //Assert
            discounts.Should().BeOfType<List<Discount>>();
            discounts.Count().Should().Be(2);
        }
        [Fact]
        public void Upsert_Get_ActionExecutes_ReturnsViewForCreate()
        {
            //Arrange

            //Act
            var result = _discountController.Upsert(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Post_InvalidModelState_ReturnsView()
        {
            _discountController.ModelState.AddModelError("Name", "Name is required");
            var discount = new Discount { };
            //Act
            var result = _discountController.Upsert(discount);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Upsert_Post_ActionExecuted_RedirectsToIndexActionAfterCreate()
        {
            //Arrange
            var discount = new Discount { Id = 1, Name = "Test", DiscountValue = 50, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(15) };
            //Act
            var result = _discountController.Upsert(discount);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void Upsert_Post_ActionExecuted_RedirectsToIndexActionAfterEdit()
        {
            //Arrange
            var discount = new Discount { Id = 1, Name = "Test", DiscountValue = 50, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(15) };
            //Act
            var result = _discountController.Upsert(discount);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void Upsert_ActionExecutes_ReturnsViewForEdit()
        {
            //Arrange
            
            //Act
            var result = _discountController.Upsert(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Edit_ActionExecuted_RedirectsToIndexAction()
        {
            //Arrange
            var discount = new Discount { Id = 1, Name = "Test", DiscountValue = 50, StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(15) };

            //Act
            var result = _discountController.Upsert(discount);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void GetAll_ActionExecutes_ReturnsJson()
        {
            //Act
            var result = _discountController.GetAll();
            //Assert
            result.Should().BeOfType<JsonResult>();
        }
        [Fact]
        public void Delete_ActionExecutes_ReturnsJson()
        {
            //Arrange
            //Act
            var result = _discountController.Delete(1);
            //Assert
            result.Should().BeOfType<JsonResult>();
        }
    }
}
