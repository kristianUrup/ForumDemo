using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserAPI.Repository;

namespace QuestionAPI.Repository.Implementation
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly QuestionApiContext _ctx;

        public QuestionRepository(QuestionApiContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Question> GetAllByUserId(int userId)
        {
            return _ctx.Questions.Where(q => q.UserId == userId);
        }

        public void Create(Question entity)
        {
            _ctx.Questions.Attach(entity).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public Question GetById(int id)
        {
            return _ctx.Questions.FirstOrDefault(q => q.Id == id);
        }

        public void Delete(int id)
        {
            _ctx.Remove(new Question {Id = id});
            _ctx.SaveChanges();
        }
    }
}