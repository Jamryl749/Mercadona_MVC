/**
 *@file IProductRepository.cs
 *@brief Interface for the Product Repository
*/
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        /**
        * @fn Update()
        * @param product is a Product class argument
        * @brief Update a given product stored in the database
        */
        void Update(Product product);
    }
}
