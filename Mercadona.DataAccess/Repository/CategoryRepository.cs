using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Repository for the category implementing the ICategoryRepository interface.
    /// </summary>
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the CategoryRepository class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementation of the Update() function from the ICategoryRepository interface.
        /// </summary>
        /// <param name="category">A Category class instance.</param>
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
