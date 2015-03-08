using System.Collections.Generic;
using System.Linq;

namespace Data.Interfaces
{
    public interface IReadOnlyRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> All();
    }

    public interface IRepository<T> : IReadOnlyRepository<T> where T : class
    {
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Update(T entity, int id);
        bool Delete(int id);
        bool Delete(IEnumerable<T> entities);
        bool SaveOrUpdate(T entity);
    }
}
