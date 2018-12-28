using B03.EE.BlanckeK.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAllInclusive());
        }

        // GET api/users/basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBasic()
        {
            return Ok(_repository.UserBasic());
        }

        // Get api/users/1
        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById(int userId)
        {
            return Ok(_repository.GetUserById(userId));
        }
    }
}