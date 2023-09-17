﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UniverstyTMS.Core.Repositories;

namespace UniverstyTMS.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UniverstyDbContext _context;

        public Repository(UniverstyDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var item in includes)
                query = query.Include(item);

            return query.FirstOrDefault(exp);
        }

        public List<T> GetAll(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var item in includes)
                query = query.Include(item);

            return query.Where(exp).ToList();
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var item in includes)
                query = query.Include(item);

            return query;
        }

        public bool IsExist(Expression<Func<T, bool>> exp, params string[] includes)
        {
            var query = _context.Set<T>().AsQueryable();
            
            foreach (var item in includes)
                query = query.Include(item);
            
            return query.Any(exp);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
