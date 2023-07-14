using Mercadona.Models;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        void Update(Discount discount);
    }
}
