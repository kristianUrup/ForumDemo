using System.Collections.Generic;
using SharedModels;

namespace QuestionAPI.Service
{
    public interface IQuestionService
    {
        IEnumerable<QuestionDto> GetAllByUserId(int userId);
        void Create(QuestionDto entity);
        QuestionDto GetById(int id);
        void Delete(int id);
    }
}