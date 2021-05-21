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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }

        public DbSet<User> Users { get; set; }
    }
}