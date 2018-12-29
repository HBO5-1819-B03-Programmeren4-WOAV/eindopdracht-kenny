using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Lib.DTO;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.EntityFrameworkCore;

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

        // update a answer
        public async Task<Answer> Update(Answer answer)
        {
            try
            {
                _db.Entry(answer).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!AnswerExists(answer.AnswerId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return answer;
        }

        // Add answer
        public async Task<Answer> AddAnswer(Answer answer)
        {
            _db.Answers.Add(answer);
            await _db.SaveChangesAsync();
            return answer;
        }

        // Delete answer
        public async Task<Answer> Delete(int id)
        {
            var answer = await _db.Answers.FindAsync(id);
            if (answer == null)
            {
                return null;
            }
            _db.Answers.Remove(answer);
            await _db.SaveChangesAsync();
            return answer;
        }


        private bool AnswerExists(int answerId)
        {
            return _db.Answers.Any(a => a.AnswerId == answerId);
        }
    }
}
