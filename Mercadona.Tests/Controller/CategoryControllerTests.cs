using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Mercadona.Tests.Controller
{
    public class CategoryControllerTests
    {
        private readonly CategoryController _categoryController;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TempDataDictionaryFactory _tempDataDictionaryFactory;
        private readonly ITempDataDictionary _tempData;

        public CategoryControllerTests()
        {
            //Dependencies
            _unitOfWork = A.Fake<IUnitOfWork>();
            _tempDataDictionaryFactory = A.Fake<TempDataDictionaryFactory>();
            _tempData = _tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

            //SUT
            _categoryController = new CategoryController(_unitOfWork)
            {
                TempData = _tempData,
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
            //Act
            var categories = _unitOfWork.Category.GetAll().ToList();
            categories.Add(new Category { });
            categories.Add(new Category { });
            //Assert
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
            //Act
            var result = _categoryController.Create(category);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Create_ActionExecuted_RedirectsToIndexAction()
        {
            //Arrange
            var category = new Category { Name = "Test Category" };
            //Act
            var result = _categoryController.Create(category);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void Edit_ActionExecutes_ReturnsViewForEdit()
        {
            //Arrange

            //Act
            var result = _categoryController.Edit(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Edit_ActionExecuted_RedirectsToIndexAction()
        {
            //Arrange
            var category = new Category { Name = "Test Category" };
            //Act
            var result = _categoryController.EditPost(category);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
        [Fact]
        public void Edit_ModelStateInvalid_RedirectsToView()
        {
            //Arrange
            _categoryController.ModelState.AddModelError("Name", "Name is required");
            var category = new Category { };
            //Act
            var result = _categoryController.EditPost(category);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Edit_ZeroId_ReturnNotFound()
        {
            //Arrange

            //Act
            var result = _categoryController.Edit(0);
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void Edit_NullId_ReturnNotFound()
        {
            //Arrange

            //Act
            var result = _categoryController.Edit(null);
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void Delete_ActionExecutes_ReturnsViewForEdit()
        {
            //Arrange

            //Act
            var result = _categoryController.Delete(1);
            //Assert
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public void Delete_ZeroId_ReturnNotFound()
        {
            //Arrange

            //Act
            var result = _categoryController.Delete(0);
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void Delete_nullId_ReturnNotFound()
        {
            //Arrange

            //Act
            var result = _categoryController.Delete(null);
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public void DeletePost_ActionExecutes_ReturnsViewForEdit()
        {
            //Arrange

            //Act
            var result = _categoryController.DeletePost(1);
            var redirestToActionResult = result.As<RedirectToActionResult>();
            //Assert
            redirestToActionResult.Equals("Index");
        }
    }
}
