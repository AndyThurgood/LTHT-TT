using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Domain.Context;
using Data.Interfaces;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public bool Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, int id)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existingEntity = _context.Set<T>().Find(id);

            if (existingEntity != null)
            {
                _context.Set<T>().Remove(existingEntity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
            return true;
        }

        public bool SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
