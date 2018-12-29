using B03.EE.BlanckeK.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private QuizRepository _repository;

        public QuizController(QuizRepository repository)
        {
            _repository = repository;
        }

        // GET api/quiz
        [HttpGet]
        public IActionResult GetAllQuizzes()
        {
            return Ok(_repository.GetAllQuizzes());
        }

        // GET api/quiz/basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetAllQuizzesBasic()
        {
            return Ok(_repository.GetQuizBasics());
        }

        // Get api/quiz/1
        [HttpGet]
        [Route("{quizId}")]
        public IActionResult GetQuizById(int quizId)
        {
            return Ok(_repository.GetQuizById(quizId));
        }

        // GET api/quiz/user/1
        [HttpGet]
        [Route("user/{userId}")]
        public IActionResult GetQuizzesForUser(string ApplicationUserId)
        {
            return Ok(_repository.GetQuizzesForUser(ApplicationUserId));
        }
    }
}