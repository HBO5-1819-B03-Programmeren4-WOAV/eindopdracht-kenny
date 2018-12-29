using System.Security.Policy;
using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Lib.Models;
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

        // PUT api/answers/1
        [HttpPut("{answerId}")]
        public async Task<IActionResult> PutAnswer([FromRoute] int answerId, [FromBody] Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (answerId != answer.AnswerId)
            {
                return BadRequest();
            }

            Answer answerToUpdate = await _repository.Update(answer);
            if (answerToUpdate == null)
            {
                return NotFound();
            }

            return Ok(answerToUpdate);
        }

        // POST api/answers
        [HttpPost]
        public async Task<IActionResult> PostAnswer([FromBody] Answer answer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repository.AddAnswer(answer);
            return CreatedAtAction(actionName: "GetAnswerById", routeValues: new {answerId = answer.AnswerId}, value: answer);
        }

        // DELETE: api/Answers/13
        [HttpDelete("{answerId}")]
        public async Task<IActionResult> DeletePublisher([FromRoute] int answerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var answer = await _repository.Delete(answerId);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }
    }
}