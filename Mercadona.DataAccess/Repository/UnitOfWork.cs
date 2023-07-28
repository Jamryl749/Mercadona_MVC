using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Class that groups all the entities interfaces (ICategoryRepository, IProductRepository, IDiscountRepository) implementing the IUnitOfWork interface.
    /// This groups all the CRUD operations for the entities, creating a better design and more readable code.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Gets the Category repository.
        /// </summary>
        public ICategoryRepository Category { get; private set; }

        /// <summary>
        /// Gets the Product repository.
        /// </summary>
        public IProductRepository Product { get; private set; }

        /// <summary>
        /// Gets the Discount repository.
        /// </summary>
        public IDiscountRepository Discount { get; private set; }

        /// <summary>
        /// Gets the ApplicationUser repository.
        /// </summary>
        public IApplicationUserRepository ApplicationUser { get; private set; }

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Product = new ProductRepository(_db);
            Discount = new DiscountRepository(_db);
        }

        /// <summary>
        /// Implementation of the Save() function from the IUnitOfWork interface.
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
