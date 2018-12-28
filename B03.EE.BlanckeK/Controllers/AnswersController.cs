using B03.EE.BlanckeK.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private AnswerRepository _repository;

        public AnswersController(AnswerRepository repository)
        {
            _repository = repository;
        }

        // GET api/answers
        [HttpGet]
        public IActionResult GetAllAnswers()
        {
            return Ok(_repository.GetAllAnswers());
        }

        // GET api/answers/basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetAnswerBasic()
        {
            return Ok(_repository.AnswerBasic());
        }

        // GET api/answers/1
        [HttpGet]
        [Route("{answerId}")]
        public IActionResult GetAnswerById(int answerId)
        {
            return Ok(_repository.GetAnswerById(answerId));
        }

        // GET api/answers/question/1
        [HttpGet]
        [Route("question/{questionId}")]
        public IActionResult GetAnswersForQuestion(int questionId)
        {
            return Ok(_repository.GetAnswersForQuestion(questionId));
        }
    }
}