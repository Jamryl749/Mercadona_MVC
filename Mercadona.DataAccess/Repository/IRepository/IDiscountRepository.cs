using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the Discount Repository.
    /// </summary>
    public interface IDiscountRepository : IRepository<Discount>
    {
        /// <summary>
        /// Update a given discount stored in the database.
        /// </summary>
        /// <param name="discount">A Discount class instance.</param>
        void Update(Discount discount);
    }
}