using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerCrudBase<Quiz, QuizRepository>
    {
        public QuizController(QuizRepository repository) : base(repository)
        {
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
            return await base.Put(quizId, quiz);
        }
    }
}