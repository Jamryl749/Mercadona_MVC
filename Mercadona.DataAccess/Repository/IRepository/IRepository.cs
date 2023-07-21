/**
 *@file IRepository.cs
 *brief Interface for the Repository
*/
using System.Linq.Expressions;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        /**
        *@fn GetAll()
        *@param includeCategories a nullable string argument
        *@param includeDiscounts a nullable string argument
        *brief Get all elements of a specific class (Category, Discount, Product, that implement the IRepository interface) from the database as an IEnumarator
        * We mainly use this fucntion to show the entities on the catalogue page or on the entities CRUD pages. 
        */
        IEnumerable<T> GetAll(string? includeCategories = null, string? includeDiscounts = null);
        /**
        *@fn Get()
        *@param filter a link expression to retrieve a specific element of a class from the database
        *@param includeCategories a nullable string argument
        *@param includeDiscounts a nullable string argument
        *brief Get a specific element of a specific class (Category, Discount, Product, that implement the IRepository interface) from the database as an entity.
        *param filter a link expression to retrieve a specific element
        * We mainly use this fucntion to Update or Delete an entity from the database. 
        */
        T Get(Expression<Func<T, bool>> filter, string? includeCategories = null, string? includeDiscounts = null);
        /**
        *@fn Add()
        *@param entity a specific class (Category, Discount, Product) argument
        *brief Add a new entity of a specific class (Category, Discount, Product, that implement the IRepository interface) to the database.
        * We mainly use this function when we create a new element (category, discount, product) on the database. 
        */
        void Add(T entity);
        /**
        *@fn Remove()
        *@param entity a specific class (Category, Discount, Product) argument
        *brief Remove an existing entity from the database.
        * We mainly use this function when we delete an existing entity (category, discount, product) from the database.
        */
        void Remove(T entity);
        /**
        *@fn RemoveRange()
        *@param entity an IEnumerable of specific class (Category, Discount, Product) argument
        *brief Remove a range of an existing entity from the database.
        * We mainly use this function when we batch delete existing entities (category, discount, product) from the database.
        */
        void RemoveRange(IEnumerable<T> entity);
    }
}
