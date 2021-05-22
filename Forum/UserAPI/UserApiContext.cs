using Microsoft.EntityFrameworkCore;

namespace UserAPI
{
    public class UserApiContext : DbContext
    {
        public UserApiContext(DbContextOptions<UserApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }
    }
}