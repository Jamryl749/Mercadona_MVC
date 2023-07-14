namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IDiscountRepository Discount { get; }
        void Save();
    }
}
