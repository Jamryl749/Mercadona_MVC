using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            var productFromDb = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if(productFromDb != null)
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
