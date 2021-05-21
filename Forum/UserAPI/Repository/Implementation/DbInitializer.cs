using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace UserAPI.Repository
{
    public class DbInitializer: IDbInitializer
    {
        public void InitializeDatabase(UserApiContext userContext)
        {
            if (!userContext.Database.EnsureCreated())
            {
                return;
            }
            User user1 = new User
            {
                
                Email = "harry@gmail.com",
                Id = 1,
                Name = "Harry",
                Password = "12345",
                Username = "HarryPotter"
            };
            
            User user2 = new User
            {
                Email = "kris@gmail.com",
                Id= 2,
                Name = "Kris",
                Password = "54321",
                Username = "KrisMcDonald"
            };
            userContext.Users.Add(user1);
            userContext.Users.Add(user2);
            userContext.SaveChanges();
        }

    }
}