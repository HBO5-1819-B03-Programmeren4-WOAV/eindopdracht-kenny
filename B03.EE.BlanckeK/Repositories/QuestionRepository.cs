using System.Collections.Generic;
using System.Linq;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class QuestionRepository
    {
        private QuizContext _db;

        public QuestionRepository(QuizContext db)
        {
            _db = db;
        }

        // returns a list of all questions
        public List<Question> GetAllQuestions()
        {
            return _db.Questions
                .Include(a => a.AnswerList)
                .ToList();
        }

        // returns a list of all questions related to a given quiz
        public List<Question> GetQuestionsByQuizId(int quizId)
        {
            return GetAllQuestions().Where(question => question.QuizId == quizId).ToList();
        }

        // returns a list of all questions but no to detailed
        public List<QuestionBasic> QuestionBasic()
        {
            return _db.Questions.Select(q => new QuestionBasic
            {
                Question = q.QuestionText,
                Id = q.QuestionId
            }).ToList();
        }
    }
}
