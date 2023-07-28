using Mercadona.DataAccess.Data;
using Mercadona.Models;
using Mercadona.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Namespace for Mercadona DataAccess DbInitializer.
/// </summary>
namespace Mercadona.DataAccess.DbInitializer
{
    /// <summary>
    /// Represents a DBInitializer that can initialize the database at application startup.
    /// </summary>
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the DbInitializer class.
        /// </summary>
        /// <param name="userManager">The user manager to interact with IdentityUser.</param>
        /// <param name="roleManager">The role manager to interact with IdentityRole.</param>
        /// <param name="db">The application database context.</param>
        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        /// <summary>
        /// Initializes the database by migrating pending migrations and seeding necessary roles and users.
        /// </summary>
        public void Initialize()
        {
            // Apply migrations if any are pending 
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
            }

            // If the Admin role does not exist, create it and assign it to a new user
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@example.com"
                }, ",Q-!nnF.aCG#8f@ss+q@").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@example.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
