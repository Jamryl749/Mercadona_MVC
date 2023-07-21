/**
 *@file CategoryRepository.cs
 *brief Repository for the category implementing the ICategoryRepository interface
*/
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /**
         *@fn Update()
         *@param category a Category class argument
         *brief Implementation of the Update() fn from the ICategoryRepository interface
        */
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
