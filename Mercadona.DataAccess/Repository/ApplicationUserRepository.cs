using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Repository for the application User implementing the IApplicationUserRepository interface.
    /// </summary>
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the ApplicationUserRepository class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementation of the Update() function from the IApplicationUserRepository interface.
        /// </summary>
        /// <param name="applicationUser">An ApplicationUser class instance.</param>
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }
    }
}
