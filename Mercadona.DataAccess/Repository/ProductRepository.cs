/**
 *@file ProductRepository.cs
 *brief Repository for the product implementing the IProductRepository interface
*/
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        /**
         *@fn Update()
         *@param product a Product class argument
         *brief Implementation of the Update() fn from the IProductRepository interface
        */
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
