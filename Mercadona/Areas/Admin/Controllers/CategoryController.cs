/**
 *@file CategoryController.cs
 *@brief Controller for the Category Entities
 *@details It determines what response to send back to a user when a user makes a browser request concerning a category.
*/
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercadona.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /**
         * @fn Index()
         * @return Category/Index.cshtml
         * @brief Return (Read and Show) the Index page for the Category entities.
         * @details In this case it shows all the categories present on the database as a list. From there you can perform CRUD (Create, Read(Show), Update, Delete) on categories.
        */
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        /**
         * @fn Create()
         * @return Category/Create.cshtml
         * @brief Return the page for the creation of Category entities.
         * @details In this case, it shows all the fields necessary to create a new category.
        */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /**
         * @fn CreatePost()
         * @param category is a new Category class element we just created
         * @return Category/Index.cshtml if the ModelState is valid
         * @return Category/Create.cshtml if the ModelState is not valid
         * @brief Return the Category Index page or on the Create page.
         * @details if (ModelState.IsValid)
         * @details Uses Add() function from the IRepository to add the new category to the database. Then we use the Save() function from the IUnitOfWork interface to save the database. And finally we return the Index page to show the list of all the categories
         * @details else
         * @details Stays on the Create page.
        */
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(Category category)
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
        /**
         * @fn Edit()
         * @param id an int
         * @return NotFound() if id is null equals 0 or the category retreived from the id is null
         * @return Category/Edit.cshtml if the category element is found
         * @brief Return the Category Edit page.
         * @details if (id != null || id != 0 ||categoryFromDb !=null)
         * @details Show the Edit.cshtml page
         * @details else
         * @details NotFound
        */
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
        /**
         * @fn EditPost()
         * @param category is an existing Category class element from the database
         * @return Category/Index.cshtml if the ModelState is valid
         * @return Category/Edit.cshtml if the ModelState is not valid
         * @brief Return the Category Index page or stay on the Edit page.
         * @details if (ModelState.IsValid)
         * @details Use the Update() function from the IRepository to edit the category on the database. Then use the Save() function from the IUnitOfWork interface to save the database. And finally we return the Index page to show the list of all the categories
         * @details else
         * @details Stays on the Edit page.
        */
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
        /**
         * @fn Delete()
         * @param id an int
         * @return NotFound() if id is null equals 0 or the category retreived from the id is null
         * @return Category/Delete.cshtml if the category element is found
         * @brief Return the Category Delete page.
         * @details if (id != null || id != 0 ||categoryFromDb !=null) 
         * @details Show the Delete.cshtml page
         * @details else
         * @details NotFound
        */
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
        /**
         * @fn DeletePost()
         * @param id an int
         * @return NotFound() if the category retreived from the id is null
         * @return Category/Index.cshtml if the category exist on the database is valid
         * @brief Return the Category Index page after the delete of an existing Category entitiy.
         * @details if (category != null)
         * @details If it is, we use the Remove() function from the IRepository to delete the category from the database. Then we use the Save() function from the IUnitOfWork interface to save the database. And finally we return the Index page to show the list of all the categories
         * @details else
         * return NotFound()
        */
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
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
