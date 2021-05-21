using System.Collections.Generic;

namespace AnswerAPI.Repository
{
    public class AnswerRepository: IRepository<Answer>
    {
        public IEnumerable<Answer> GetAllByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Answer> GetAllByQuestionId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Answer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}