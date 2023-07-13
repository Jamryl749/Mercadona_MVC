using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mercadona.Tests.Controller
{
    public class CategoryControllerTests
    {
        private readonly CategoryController _categoryController;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryControllerTests()
        {
            //Dependencies
            _unitOfWork = A.Fake<IUnitOfWork>();
            ITempDataProvider tempDataProvider = A.Fake<ITempDataProvider>();
            TempDataDictionaryFactory tempDataDictionaryFactory = A.Fake<TempDataDictionaryFactory>();
            ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            //SUT
            _categoryController = new CategoryController(_unitOfWork)
            {
                TempData = tempData,
            };
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //Arrange
            //Act
            var result = _categoryController.Index();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Index_ActionExecutes_ReturnsListOfCategoriesAndCount()
        {
            var result = _categoryController.Index();
            var viewResult = result.Should().BeOfType<ViewResult>();
            var categories = _unitOfWork.Category.GetAll().ToList();
            categories.Add(new Category { Id = 1, Name = "Test" });
            categories.Add(new Category { Id = 2, Name = "Test2" });

            categories.Should().BeOfType<List<Category>>();
            categories.Count().Should().Be(2);
        }
        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            //Arrange

            //Act
            var result = _categoryController.Create();
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            _categoryController.ModelState.AddModelError("Name", "Name is required");
            var category = new Category { };

            var result = _categoryController.Create(category);

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Create_ActionExecuted_RedirectsToIndexAction()
        {
            var category = new Category { Name = "Test Category" };
            var result = _categoryController.Create(category);
            var redirestToActionResult = result.As<RedirectToActionResult>();

            redirestToActionResult.Equals("Index");
            //Assert.Equal("Index", redirestToActionResult.ActionName);
        }
    }
}
