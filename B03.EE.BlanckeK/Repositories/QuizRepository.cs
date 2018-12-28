using System.Collections.Generic;
using System.Linq;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class QuizRepository
    {
        private QuizContext _db;

        public QuizRepository(QuizContext db)
        {
            _db = db;
        }

        // returns a list of all the quizzes
        public List<Quiz> GetAllQuizzes()
        {
            return _db.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(a => a.AnswerList)
                .ToList();
        }

        // returns a list of all the quizzes without to much details
        public List<QuizBasic> GetQuizBasics()
        {
            return _db.Quizzes.Select(q => new QuizBasic
            {
                QuizId = q.QuizId,
                QuizName = q.QuizName
            }).ToList();
        }

        // returns a quiz with a specific ID
        public Quiz GetQuizById(int quizId)
        {
            return GetAllQuizzes().FirstOrDefault(quiz => quiz.QuizId == quizId);
        }

        // returns a list off all quizzes from a specific user
        public List<Quiz> GetQuizzesForUser(int userId)
        {
            return GetAllQuizzes().Where(q => q.UserId == userId).ToList();
        }
    }
}
