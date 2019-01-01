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
    }
}