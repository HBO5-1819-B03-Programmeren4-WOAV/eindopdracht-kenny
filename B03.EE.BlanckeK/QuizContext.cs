using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api
{
    public class QuizContext : IdentityDbContext<ApplicationUser>
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers")
                .HasMany(a => a.Quizzes).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Quiz>()
                .ToTable("Quiz")
                .HasMany(q => q.Questions).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Question>()
                .ToTable("Questions")
                .HasMany(a => a.AnswerList).WithOne().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Answer>()
                .ToTable("Answer");




        }

        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

    }
}
