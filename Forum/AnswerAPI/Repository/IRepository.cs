using System.Collections.Generic;

namespace AnswerAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByUserId(int userId);
        IEnumerable<T> GetAllByQuestionId(int questionId);
        void Create(T entity);
    }
}