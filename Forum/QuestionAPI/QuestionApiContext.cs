using Microsoft.EntityFrameworkCore;

namespace QuestionAPI
{
    public class QuestionApiContext : DbContext
    {
        public QuestionApiContext(DbContextOptions<QuestionApiContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);
        }
    }
}