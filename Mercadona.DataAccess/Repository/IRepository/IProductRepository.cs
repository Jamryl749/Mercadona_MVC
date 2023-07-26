using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the Product Repository.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Update a given product stored in the database.
        /// </summary>
        /// <param name="product">A Product class instance.</param>
        void Update(Product product);
    }
}
