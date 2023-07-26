using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the Category Repository.
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Update a given category stored in the database.
        /// </summary>
        /// <param name="category">A Category class instance.</param>
        void Update(Category category);
    }
}

