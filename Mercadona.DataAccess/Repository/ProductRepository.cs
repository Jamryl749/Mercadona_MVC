using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Repository for the product implementing the IProductRepository interface.
    /// </summary>
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the ProductRepository class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementation of the Update() function from the IProductRepository interface.
        /// </summary>
        /// <param name="product">A Product class instance.</param>
        public void Update(Product product)
        {
            var productFromDb = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productFromDb != null)
            {
                productFromDb.Id = product.Id;
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.Category = product.Category;
                productFromDb.Name = product.Name;
                productFromDb.Desc = product.Desc;
                productFromDb.ImageUrl = product.ImageUrl;
                productFromDb.Price = product.Price;
                if (product.DiscountId != 0)
                {
                    productFromDb.DiscountId = product.DiscountId;
                }
                productFromDb.DiscountedPrice = product.DiscountedPrice;
                if (product.ImageUrl != null)
                {
                    productFromDb.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}

