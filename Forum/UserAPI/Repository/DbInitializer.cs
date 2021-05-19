using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace UserAPI.Repository
{
    public class DbInitializer: IDbInitializer
    {
        public void InitializeDatabase(UserApiContext userContext)
        {
            User user1 = new User
            {
                Answers = new List<AnswerDto>(),
                Email = "harry@gmail.com",
                Id = 1,
                Name = "Harry",
                Password = "12345",
                Questions = new List<QuestionDto>(),
                Username = "HarryPotter"
            };
            
            User user2 = new User
            {
                Answers = new List<AnswerDto>(),
                Email = "kris@gmail.com",
                Id = 1,
                Name = "Kris",
                Password = "54321",
                Questions = new List<QuestionDto>(),
                Username = "KrisMcDonald"
            };
            userContext.Users.AddRange(new List<User>{user1,user2});
        }

    }
}