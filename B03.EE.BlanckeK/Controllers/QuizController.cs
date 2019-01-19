using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerCrudBase<Quiz, QuizRepository>
    {
        private QuizContext Db;

        public QuizController(QuizRepository repository, QuizContext db) : base(repository)
        {
            Db = db;
        }

        // GET api/quiz
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await Repository.GetAllInclusive());
        }

        // GET api/Quiz/1
        [HttpGet]
        [Route("{id}")]
        public override async Task<IActionResult> Get(string id)
        {
            return Ok(await Repository.GetAllInclusiveById(id));
        }


        // GET api/quiz/basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetQuizzesBasic()
        {
            return Ok(await Repository.GetQuizBasics());
        }

        // GET api/quiz/user/1
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetQuizzesForUser(string userId)
        {
            return Ok(await Repository.ListFiltered(user => user.Id == userId));
        }

        [HttpPost]
        public override async Task<IActionResult> Post([FromBody] Quiz quiz)
        {
            return await base.Post(quiz);
        }

        [HttpPut]
        [Route("{quizId}")]
        public override async Task<IActionResult> Put([FromRoute] string quizId, [FromBody] Quiz quiz)
        {
            Quiz existingQuiz = await Repository.GetAllInclusiveById(quizId);
            List<Answer> newAnswers = new List<Answer>();

            if (existingQuiz == null) return await base.Put(quizId, quiz);
            foreach (var question in quiz.Questions)
            {
                if (question.Id == null)
                {
                    Db.Entry(question).State = EntityState.Added;
                    foreach (var newAnswer in question.AnswerList)
                    {
                        Db.Entry(newAnswer).State = EntityState.Added;
                    }
                }
                else
                {
                    if (existingQuiz.Questions.Any(eq => eq.Id == question.Id))
                        Db.Entry(question).State = EntityState.Modified;
                    else
                    {
                        Db.Entry(question).State = EntityState.Added;
                        foreach (var answer in question.AnswerList)
                        {
                            Db.Entry(answer).State = EntityState.Added;
                        }
                    }

                    foreach (var answer in question.AnswerList)
                    {
                        Db.Entry(answer).State = answer.Id == null ? EntityState.Added : EntityState.Modified;
                        newAnswers.Add(answer);
                    }
                }
            }
            foreach (var existingQuestion in existingQuiz.Questions)
            {
                if (existingQuestion == null) continue;
                if (quiz.Questions.Any(eq => eq.Id == existingQuestion.Id) == false)
                {
                    Db.Entry((object)existingQuestion).State = EntityState.Deleted;
                }

                foreach (var existingAnswer in existingQuestion.AnswerList)
                {
                    if (existingAnswer == null) continue;
                    if (newAnswers.Any(ea => ea.Id == existingAnswer.Id) == false)
                    {
                        Db.Entry((object)existingAnswer).State = EntityState.Deleted;
                    }
                }
                Db.Entry(quiz).State = EntityState.Modified;
            }
            return await base.Put(quizId, quiz);
        }
    }
}
