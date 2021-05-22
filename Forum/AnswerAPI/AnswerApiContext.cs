using Microsoft.EntityFrameworkCore;

namespace AnswerAPI
{
    public class AnswerApiContext : DbContext
    {
        public AnswerApiContext(DbContextOptions<AnswerApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasKey(a => a.Id);
        }
        
        public DbSet<Answer> Answers { get; set; }

        
    }
}