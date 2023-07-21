/**
 *@file DiscountRepository.cs
 *brief Repository for the discount implementing the IDiscountRepository interface
*/
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        private readonly ApplicationDbContext _db;
        public DiscountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        /**
         *@fn Update()
         *@param discount a Discount class argument
         *brief Implementation of the Update() fn from the IDiscountRepository interface
        */
        public void Update(Discount discount)
        {
            _db.Discounts.Update(discount);
        }
    }
}
