using System;
using System.Collections.Generic;

namespace AnswerAPI.Repository.Implementation
{
    public class DbInitializer: IDbInitializer
    {
        public void InitializeDatabase(AnswerApiContext answerApiContext)
        {
            if (answerApiContext.Database.EnsureCreated())
            {
                return;
            }
            var answer1 = new Answer
            {
                UserId = 1,
                QuestionId = 1,
                Created = new DateTime(2021,05,20),
                Description = "Yeah that's true"
            };
            var answer2 = new Answer
            {
                UserId = 1,
                QuestionId = 2,
                Created = DateTime.Now,
                Description = "It is in the API, you need to make it, not in the frontend"
            };
            var answer3 = new Answer
            {
                UserId = 2,
                QuestionId = 1,
                Created = new DateTime(2021,05,21),
                Description = "That is not true"
            };
            answerApiContext.Answers.AddRange(new List<Answer> {answer1,answer2,answer3});
            answerApiContext.SaveChanges();
        }
    }
}