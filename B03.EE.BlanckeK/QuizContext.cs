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
                .HasData(
                    new ApplicationUser
                    {
                        FirstName = "Kenny",
                        LastName = "Blancke",
                        Id = "KennyBlancke@icloud.com"
                    });
            builder.Entity<Quiz>()
               .ToTable("Quiz")
               .HasData(
                   new Quiz
                   {
                       Id = "1",
                       QuizName = "Eerste quiz",
                       ApplicationUserId = "KennyBlancke@icloud.com"

                   });
            builder.Entity<Answer>()
                .ToTable("Answer")
                .HasData(
                    new Answer
                    {
                        Id = "1",
                        QuestionId = "1",
                        AnswerText = "Correct antwoord op eerste vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        Id = "2",
                        QuestionId = "1",
                        AnswerText = "Eerste foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "3",
                        QuestionId = "1",
                        AnswerText = "tweede foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "4",
                        QuestionId = "1",
                        AnswerText = "derde foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "5",
                        QuestionId = "2",
                        AnswerText = "Eerste foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "6",
                        QuestionId = "2",
                        AnswerText = "Tweede foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "7",
                        QuestionId = "2",
                        AnswerText = "Juiste antwoord op tweede vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        Id = "8",
                        QuestionId = "2",
                        AnswerText = "derde foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "9",
                        QuestionId = "3",
                        AnswerText = "Correct antwoord op derde vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        Id = "10",
                        QuestionId = "3",
                        AnswerText = "Eerste foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "11",
                        QuestionId = "3",
                        AnswerText = "tweede foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        Id = "12",
                        QuestionId = "3",
                        AnswerText = "derde foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    });
            builder.Entity<Question>()
                .ToTable("Questions")
                .HasData(
                    new Question
                    {
                        Id = "1",
                        QuestionText = "Eerste vraag?",
                        QuizId = "1",
                        SortId = 1
                    },
                    new Question
                    {
                        Id = "2",
                        QuestionText = "Tweede vraag?",
                        QuizId = "1",
                        SortId = 2
                    },
                    new Question
                    {
                        Id = "3",
                        QuestionText = "Derde vraag?",
                        QuizId = "1", 
                        SortId = 3
                    });

        }

        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }

    }
}
