/**
 *@file UnitOfWork.cs
 *brief Class that group all the entities interfaces (ICategoryRepository, IProductRepository, IDiscountRepository) implementing the IUnitOfWork interface
 *This regroup all the CRUD operations for the entities, creating a better design and more readable code. 
*/
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;

namespace Mercadona.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IDiscountRepository Discount { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            Discount = new DiscountRepository(_db);
        }
        /**
         *@fn Save()
         *brief Implementation of the Save() fn from the IUnitOfWork interface
        */
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
