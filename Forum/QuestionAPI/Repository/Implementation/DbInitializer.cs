using System;
using System.Collections.Generic;

namespace QuestionAPI.Repository.Implementation
{
    public class DbInitializer: IDbInitializer
    {
        public void InitializeDatabase(QuestionApiContext questionApiContext)
        {
            if (!questionApiContext.Database.EnsureCreated())
            {
                return;
            }
            var question1 = new Question
            {
                UserId = 2,
                Created = new DateTime(2020,10,05),
                Title = "Why is my api not working",
                Description = "I have tried everything, and it just doesn't work"
            };
            var question2 = new Question
            {
                UserId = 1,
                Created = new DateTime(2020,10,25),
                Title = "Can i use an api",
                Description = "Is it possible to use an api to my webapp"
            };
            
            questionApiContext.Questions.AddRange(new List<Question>{question1,question2});
            questionApiContext.SaveChanges();
        }
    }
}