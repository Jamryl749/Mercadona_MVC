using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the ApplicationUser Repository.
    /// </summary>
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Update a given application User stored in the database.
        /// </summary>
        /// <param name="applicationUser">An ApplicationUser class instance.</param>
        void Update(ApplicationUser applicationUser);
    }
}

