using System;
using B03.EE.BlanckeK.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .ToTable("User")
                .HasData(
                    new User
                    {
                        DateTime = DateTime.Now,
                        FirstName = "Kenny",
                        LastName = "Blancke",
                        Password = "Test",
                        UserId = 1
                    });
            builder.Entity<Quiz>()
                    .ToTable("Quiz")
                    .HasData(
                        new Quiz
                        {
                            QuizId = 1,
                            QuizName = "Eerste quiz",
                            UserId = 1,
                        });
            builder.Entity<Answer>()
                .ToTable("Answer")
                .HasData(
                    new Answer
                    {
                        AnswerId = 1,
                        QuestionId = 1,
                        AnswerText = "Correct antwoord op eerste vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        AnswerId = 2,
                        QuestionId = 1,
                        AnswerText = "Eerste foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 3,
                        QuestionId = 1,
                        AnswerText = "tweede foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 4,
                        QuestionId = 1,
                        AnswerText = "derde foutieve antwoord op eerste vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 5,
                        QuestionId = 2,
                        AnswerText = "Eerste foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 6,
                        QuestionId = 2,
                        AnswerText = "Tweede foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 7,
                        QuestionId = 2,
                        AnswerText = "Juiste antwoord op tweede vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        AnswerId = 8,
                        QuestionId = 2,
                        AnswerText = "derde foutieve antwoord op tweede vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 9,
                        QuestionId = 3,
                        AnswerText = "Correct antwoord op derde vraag",
                        IsCorrectAnswer = true
                    },
                    new Answer
                    {
                        AnswerId = 10,
                        QuestionId = 3,
                        AnswerText = "Eerste foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 11,
                        QuestionId = 3,
                        AnswerText = "tweede foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    },
                    new Answer
                    {
                        AnswerId = 12,
                        QuestionId = 3,
                        AnswerText = "derde foutieve antwoord op derde vraag",
                        IsCorrectAnswer = false
                    });
            builder.Entity<Question>()
                .ToTable("Questions")
                .HasData(
                    new Question
                    {
                        QuestionId = 1,
                        QuestionText = "Eerste vraag?",
                        QuizId = 1
                    },
                    new Question
                    {
                        QuestionId = 2,
                        QuestionText = "Tweede vraag?",
                        QuizId = 1

                    },
                    new Question
                    {
                        QuestionId = 3,
                        QuestionText = "Derde vraag?",
                        QuizId = 1
                    });

        }
    }
}
