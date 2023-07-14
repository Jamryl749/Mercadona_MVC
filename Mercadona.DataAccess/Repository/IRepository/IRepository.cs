﻿using System.Linq.Expressions;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Category
        IEnumerable<T> GetAll(string? includeCategories = null, string? includeDiscounts = null);
        T Get(Expression<Func<T, bool>> filter, string? includeCategories = null, string? includeDiscounts = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
