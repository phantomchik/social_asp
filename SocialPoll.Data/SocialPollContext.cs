using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialPoll.Data.Models;

namespace SocialPoll.Data
{
    public class SocialPollContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = SocialPollDb; Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Variable>()
                .HasOne(v => v.Question)
                .WithMany(q => q.Variables)
                .HasForeignKey(v => v.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Variable>()
                .HasOne(v => v.Answer)
                .WithOne(a => a.Variable)
                .HasForeignKey<Variable>(v => v.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
