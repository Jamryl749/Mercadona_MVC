/**
 *@file IDiscountRepository.cs
 *brief Discount for the Product Repository
*/
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        /**
        * @fn Update()
        * @param discount is a Discount class argument
        * @brief Update a given dicount stored in the database
        */
        void Update(Discount discount);
    }
}
