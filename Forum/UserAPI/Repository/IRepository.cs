using System.Collections.Generic;

namespace UserAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}