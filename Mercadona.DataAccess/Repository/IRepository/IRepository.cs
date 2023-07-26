using System.Linq.Expressions;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the Repository.
    /// </summary>
    /// <typeparam name="T">The type of object this repository works with.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all elements of a specific class from the database as an enumerator.
        /// </summary>
        /// <param name="includeCategories">A nullable string argument.</param>
        /// <param name="includeDiscounts">A nullable string argument.</param>
        /// <returns>An IEnumerable of objects of type T.</returns>
        IEnumerable<T> GetAll(string? includeCategories = null, string? includeDiscounts = null);

        /// <summary>
        /// Get a specific element of a specific class from the database as an entity.
        /// </summary>
        /// <param name="filter">A lambda expression for retrieving a specific element.</param>
        /// <param name="includeCategories">A nullable string argument.</param>
        /// <param name="includeDiscounts">A nullable string argument.</param>
        /// <returns>An object of type T.</returns>
        T Get(Expression<Func<T, bool>> filter, string? includeCategories = null, string? includeDiscounts = null);

        /// <summary>
        /// Add a new entity of a specific class to the database.
        /// </summary>
        /// <param name="entity">An object of type T.</param>
        void Add(T entity);

        /// <summary>
        /// Remove an existing entity from the database.
        /// </summary>
        /// <param name="entity">An object of type T.</param>
        void Remove(T entity);

        /// <summary>
        /// Remove a range of existing entities from the database.
        /// </summary>
        /// <param name="entity">An IEnumerable of objects of type T.</param>
        void RemoveRange(IEnumerable<T> entity);
    }
}
