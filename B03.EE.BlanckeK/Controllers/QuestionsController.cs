
using B03.EE.BlanckeK.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private QuestionRepository _repository;

        public QuestionsController(QuestionRepository repository)
        {
            _repository = repository;
        }

        // GET api/questions
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            return Ok(_repository.GetAllQuestions());
        }

        // GET api/questions/basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetQuestionBasic()
        {
            return Ok(_repository.QuestionBasic());
        }

        // Get api/questions/quiz/1
        [HttpGet]
        [Route("quiz/{quizId}")]
        public IActionResult GetQuestionsForQuiz(int quizId)
        {
            return Ok(_repository.GetQuestionsByQuizId(quizId));
        }
    }
}