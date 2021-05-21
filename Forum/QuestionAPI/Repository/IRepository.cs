using System.Collections;
using System.Collections.Generic;

namespace UserAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllByUserId(int userId);
        void Create(T entity);
        T GetById(int id);
        void Delete(int id);
    }
}