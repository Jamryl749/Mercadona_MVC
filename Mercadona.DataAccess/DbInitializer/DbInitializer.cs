/**
 *@file DbInitializer.cs
 *brief Use to create and seed the first Role and AdminUser of the website to the database when deploying
*/
using Mercadona.DataAccess.Data;
using Mercadona.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Mercadona.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            /**
             * Add migrations if they are not applied
            */ 
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }

            /**
             * Create roles if they are not created
            */
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

                /**
                * If roles are not created, then we will create admin user as well
                */
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "Admin",
                    Email = "admin@example.com"
                }, ",Q-!nnF.aCG#8f@ss+q@").GetAwaiter().GetResult();

                IdentityUser user = _userManager.Users.FirstOrDefault(u => u.Email == "admin@example.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}
