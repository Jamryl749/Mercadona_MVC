/**
 *@file Repository.cs
 *brief Common Repository for the 3 entities (product, discount, category) implementing the IRepository interface
*/
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mercadona.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
            _db.Products.Include(x => x.Category).Include(y => y.Discount);
        }
        /**
         *@fn Add()
         *@param entity a specific class (Category, Discount, Product) argument
         *brief Implementation of the Add() fn from the IRepository interface
        */
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }
        /**
         *@fn Get()
         *@param filter a link expression to retrieve a specific element of a class from the database
         *@param includeCategories a nullable string argument
         *@param includeDiscounts a nullable string argument
         *brief Implementation of the Get() fn from the IRepository interface
        */
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
        /**
         *@fn GetAll()
         *@param includeCategories a nullable string argument
         *@param includeDiscounts a nullable string argument
         *brief Implementation of the GetAll() fn from the IRepository interface
        */
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
        /**
         *@fn Remove()
         *@param entity a specific class (Category, Discount, Product) argument
         *brief Implementation of the Remove() fn from the IRepository interface
         */
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        /**
         *@fn RemoveRange()
         *@param entity an IEnumerable of specific class (Category, Discount, Product) argument
         *brief Implementation of the RemoveRange() fn from the IRepository interface
        */
        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
