using System.Collections.Generic;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerCrudBase<Question, QuestionRepository>
    {

        public QuestionsController(QuestionRepository repository) : base(repository)
        {
        }

        // GET api/quiz
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await Repository.GetAllInclusive());
        }


        // GET api/questions/basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetQuestionBasic()
        {
            return Ok(await Repository.QuestionBasic());
        }

        // Get api/questions/quiz/1
        [HttpDelete("quiz/{quizId}")]
        public async Task<IActionResult> DeleteQuestionsForQuiz(string quizId)
        {
            var questionsToDelete = await Repository.GetAllQuestionsForQuiz(quizId);
            foreach (var question in questionsToDelete)
            {
               await Repository.Delete(question);
            }
            return Ok();
        }

        [HttpPut("quiz/{quizId}")]
        public async Task<IActionResult> AddQuestionListForQuiz(List<Question> newQuestionList)
        {
            var questionsToPut = newQuestionList;
            foreach (var question in questionsToPut)
            {
                await Repository.Add(question);
            }
            return Ok();
        }
    }
}