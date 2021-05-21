using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnswerAPI.Repository.Implementation
{
    public class AnswerRepository: IRepository<Answer>
    {
        private AnswerApiContext _ctx;

        public AnswerRepository(AnswerApiContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Answer> GetAllByUserId(int userId)
        {
            return _ctx.Answers.Where(answer => answer.UserId == userId);
        }

        public IEnumerable<Answer> GetAllByQuestionId(int questionId)
        {
            return _ctx.Answers.Where(answer => answer.QuestionId == questionId);
        }

        public void Create(Answer entity)
        {
            _ctx.Answers.Attach(entity).State = EntityState.Added;
            _ctx.SaveChanges();
        }
    }
}