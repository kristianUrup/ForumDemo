using System.Collections;
using System.Collections.Generic;

namespace AnswerAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllByUserId(int userId);
        IEnumerable<T> GetAllByQuestionId(int questionId);
        void Create(T entity);
    }
}