/**
 *@file IUnitOfWork.cs
 *brief Interface for the UnitOfWork
*/
namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IDiscountRepository Discount { get; }
        /**
        *@fn Save()
        *brief Save the changes done by CRUD to the database.
        * We use this function after CRUD operations on entities (category, discount, product) to effectively save the changes to the database.
        */
        void Save();
    }
}
