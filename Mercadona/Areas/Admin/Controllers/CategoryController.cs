using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Handles the functionality related to categories, including viewing, creating, editing, and deleting categories.
/// </summary>
namespace Mercadona.Areas.Admin.Controllers
{
    /// <summary>
    /// The CategoryController is responsible for handling CRUD operations for categories.
    /// </summary>
    /// <remarks>
    /// The controller is decorated with the Authorize attribute, so only users in the "Admin" role can use its methods.
    /// </remarks>
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the CategoryController class.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work pattern, used for manipulating database records.</param>
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <returns>View displaying the list of categories.</returns>
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        /// <summary>
        /// Displays a form for creating a new category.
        /// </summary>
        /// <returns>View displaying the form for creating a category.</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of a form for creating a new category.
        /// </summary>
        /// <param name="category">Category to be created.</param>
        /// <returns>Redirects to index action after successful creation, otherwise returns the same view for displaying validation errors.</returns>
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Category category)
        {
            List<Category> categories = new List<Category>();
            categories = _unitOfWork.Category.GetAll().ToList();
            if(!categories.Any(x => x.Name.ToLower() == category.Name.ToLower()))
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category created successfully";
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                Span<char> destination = stackalloc char[1];
                TempData["error"] = $"The \"{char.ToUpper(category.Name[0]) + category.Name.Substring(1)}\" category already exists";
                return View();
            }
        }
        /// <summary>
        /// Displays a form for editing an existing category.
        /// </summary>
        /// <param name="id">ID of the category to be edited.</param>
        /// <returns>View displaying the form for editing a category.</returns>

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        /// <summary>
        /// Handles the submission of a form for editing a category.
        /// </summary>
        /// <param name="category">Edited category.</param>
        /// <returns>Redirects to index action after successful edit, otherwise returns the same view for displaying validation errors.</returns>
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Displays a form for deleting a category.
        /// </summary>
        /// <param name="id">ID of the category to be deleted.</param>
        /// <returns>View displaying the form for deleting a category.</returns>
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        /// <summary>
        /// Handles the submission of a form for deleting a category.
        /// </summary>
        /// <param name="id">ID of the category to be deleted.</param>
        /// <returns>Redirects to index action after successful deletion.</returns>
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitOfWork.Category.Get(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Operation successful";
            return RedirectToAction("Index");
        }
    }
}
