using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

/// <summary>
/// Namespace for Mercadona.DataAccess.Repository.
/// </summary>
namespace Mercadona.DataAccess.Repository
{
    /// <summary>
    /// Common Repository for the 3 entities (product, discount, category) implementing the IRepository interface.
    /// </summary>
    /// <typeparam name="T">The type of object this repository works with.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="db">The application database context.</param>
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
            _db.Products.Include(x => x.Category).Include(y => y.Discount);
        }

        /// <summary>
        /// Implementation of the Add() function from the IRepository interface.
        /// </summary>
        /// <param name="entity">An object of type T.</param>
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        /// <summary>
        /// Implementation of the Get() function from the IRepository interface.
        /// </summary>
        /// <param name="filter">A lambda expression for retrieving a specific element.</param>
        /// <param name="includeCategories">A nullable string argument.</param>
        /// <param name="includeDiscounts">A nullable string argument.</param>
        /// <returns>An object of type T.</returns>
        public T Get(Expression<Func<T, bool>> filter, string? includeCategories = null, string? includeDiscounts = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeCategories))
            {
                foreach (var includeProp in includeCategories.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (!string.IsNullOrEmpty(includeDiscounts))
            {
                foreach (var includeProp in includeDiscounts.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Implementation of the GetAll() function from the IRepository interface.
        /// </summary>
        /// <param name="includeCategories">A nullable string argument.</param>
        /// <param name="includeDiscounts">A nullable string argument.</param>
        /// <returns>An IEnumerable of objects of type T.</returns>
        public IEnumerable<T> GetAll(string? includeCategories = null, string? includeDiscounts = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeCategories))
            {
                foreach (var includeProp in includeCategories.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (!string.IsNullOrEmpty(includeDiscounts))
            {
                foreach (var includeProp in includeDiscounts.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        /// <summary>
        /// Implementation of the Remove() function from the IRepository interface.
        /// </summary>
        /// <param name="entity">An object of type T.</param>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Implementation of the RemoveRange() function from the IRepository interface.
        /// </summary>
        /// <param name="entity">An IEnumerable of objects of type T.</param>
        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
