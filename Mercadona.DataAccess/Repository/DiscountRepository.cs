using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Mercadona.Models;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Repository for the discount implementing the IDiscountRepository interface.
    /// </summary>
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Initializes a new instance of the DiscountRepository class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public DiscountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementation of the Update() function from the IDiscountRepository interface.
        /// </summary>
        /// <param name="discount">A Discount class instance.</param>
        public void Update(Discount discount)
        {
            var discountFromDb = _db.Discounts.FirstOrDefault(x => x.Id == discount.Id);
            if (discountFromDb != null)
            {
                discountFromDb.Id = discount.Id;
                discountFromDb.Name = discount.Name;
                discountFromDb.DiscountValue = discount.DiscountValue;
                discountFromDb.StartDate = discount.StartDate;
                discountFromDb.EndDate = discount.EndDate;
            }
        }
    }
}
