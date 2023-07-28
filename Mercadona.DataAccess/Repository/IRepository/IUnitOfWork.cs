/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.IRepository.
/// </summary>
namespace Mercadona.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Interface for the UnitOfWork.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the Category repository instance.
        /// </summary>
        ICategoryRepository Category { get; }

        /// <summary>
        /// Gets the Product repository instance.
        /// </summary>
        IProductRepository Product { get; }

        /// <summary>
        /// Gets the Discount repository instance.
        /// </summary>
        IDiscountRepository Discount { get; }

        /// <summary>
        /// Gets the ApplicationUser repository instance.
        /// </summary>
        IApplicationUserRepository ApplicationUser { get; }

        /// <summary>
        /// Save the changes done by CRUD operations to the database.
        /// Use this method after CRUD operations on entities (category, discount, product) to effectively save the changes to the database.
        /// </summary>
        void Save();
    }
}
