using System.Collections.Generic;
using System.Linq;
using B03.EE.BlanckeK.DTO;
using B03.EE.BlanckeK.Models;

namespace B03.EE.BlanckeK.Api.Repositories
{
    public class AnswerRepository
    {
        private QuizContext _db;

        public AnswerRepository(QuizContext db)
        {
            _db = db;
        }

        // returns a list of all answers
        public List<Answer> GetAllAnswers()
        {
            return _db.Answers.ToList();
        }

        // returns a list of all answers but without all the details of it
        public List<AnswerBasic> AnswerBasic()
        {
            return _db.Answers.Select(a => new AnswerBasic
            {
                AnswerId = a.AnswerId,
                AnswerText = a.AnswerText,
                IsCorrectAnswer = a.IsCorrectAnswer
            }).ToList();
        }

        // returns a answers with a specific ID
        public Answer GetAnswerById(int answerId)
        {
            return GetAllAnswers().FirstOrDefault(answer => answer.AnswerId == answerId);
        }

        // returns a list of answers for a specific question
        public List<Answer> GetAnswersForQuestion(int questionId)
        {
            return GetAllAnswers().Where(q => q.QuestionId == questionId).ToList();
        }
    }
}
