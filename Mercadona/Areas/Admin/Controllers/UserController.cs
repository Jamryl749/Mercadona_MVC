using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using Mercadona.Models.ViewModels;
using Mercadona.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


/// <summary>
/// Handles the functionality related to users, including viewing, creating, editing, and deleting users.
/// </summary>
namespace Mercadona.Areas.Admin.Controllers
{
    /// <summary>
    /// UserController is responsible for handling CRUD operations for users.
    /// </summary>
    /// <remarks>
    /// This controller is decorated with the Authorize attribute, allowing only users with the "Admin" role to use its methods.
    /// </remarks>
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <returns>View displaying the list of users.</returns>
        public IActionResult Index()
        {
            List<ApplicationUser> objApplicationUserList = _db.ApplicationUsers.ToList();
            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objApplicationUserList)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

            }
            return View(objApplicationUserList);
        }

        [HttpGet]
        public IActionResult LockUnlock(string  id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault( u => u.Id == id);
            if(objFromDb == null)
            {
                return NotFound();
            }

            if(objFromDb.LockoutEnd !=  null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //user is currently locked and need to be unlocked
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
