/**
 *@file ICategoryRepository.cs
 *brief Interface for the Category Repository
*/
using Mercadona.Models;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        /**
        * @fn Update()
        * @param category is a Category class argument
        * @brief Update a given category stored in the database
        */
        void Update(Category category);
    }
}
