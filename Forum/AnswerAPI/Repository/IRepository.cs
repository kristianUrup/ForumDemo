using System.Collections;
using System.Collections.Generic;

namespace AnswerAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllByUserId(int id);
        IEnumerable<T> GetAllByQuestionId(int id);
        void Create(T entity);
    }
}