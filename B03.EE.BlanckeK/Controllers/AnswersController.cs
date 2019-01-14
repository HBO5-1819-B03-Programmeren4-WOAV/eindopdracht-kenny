using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerCrudBase<Answer, AnswerRepository>
    {
        public AnswersController(AnswerRepository repository): base(repository)
        {
        }

        // GET api/answers/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetAnswerBasic()
        {
            return Ok(await Repository.AnswerBasic());
        }

        // Get api/answers/question/ddb84a1c-1349-46e8-a19b-bd854490474a
        [HttpGet]
        [Route("question/{questionId}")]
        public async Task<IActionResult> GetAnswersForQuestion(string questionId)
        {
            return Ok(await Repository.ListFiltered(a => a.QuestionId == questionId));
        }
    }
}