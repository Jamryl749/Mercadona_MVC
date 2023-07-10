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
    public class DiscountRepository : Repository<Discount>, IDiscountRepository 
    {
        private ApplicationDbContext _db;
        public DiscountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Discount discount)
        {
            _db.Discounts.Update(discount);
        }
    }
}
