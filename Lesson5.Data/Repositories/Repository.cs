using Lesson5.Core.Entities;
using Lesson5.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            //_context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            //_context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
               // _context.SaveChanges();
            }
        }
    }
}
