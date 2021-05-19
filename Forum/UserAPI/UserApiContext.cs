using Microsoft.EntityFrameworkCore;
using SharedModels;

namespace UserAPI
{
    public class UserApiContext: DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}