﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjectFramework.Domain;

namespace ProjectFramework.Infrastructure
{
    public class RepositoryBase<TKey, T> : IRepository<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public T Get(TKey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return  _context.Set<T>().Any(expression);
        }
    }
}
