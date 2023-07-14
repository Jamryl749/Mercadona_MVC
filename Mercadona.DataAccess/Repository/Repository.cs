using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mercadona.DataAccess.Data;
using Mercadona.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

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

        public IEnumerable<T> GetAll(string? includeCategories = null, string? includeDiscounts = null)
        {
            IQueryable<T> query = _dbSet;
            if(!string.IsNullOrEmpty(includeCategories))
            {
                foreach(var includeProp in includeCategories.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
    }
}
