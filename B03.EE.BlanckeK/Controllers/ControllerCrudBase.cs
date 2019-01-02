using System.Threading.Tasks;
using B03.EE.BlanckeK.Api.Repositories.Base;
using B03.EE.BlanckeK.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace B03.EE.BlanckeK.Api.Controllers
{
    public class ControllerCrudBase<T, TR> : ControllerBase where T : EntityBase where TR : MainRepository<T>
    {
        protected TR Repository;

        public ControllerCrudBase(TR r)
        {
            Repository = r;
        }

        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(await Repository.ListAll());
        }

        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            return Ok(await Repository.GetById(id));
        }

        // PUT: api/T/5
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] string id, [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != entity.Id) return BadRequest("Het opgegeven ID bestaat niet");
            var e = await Repository.Update(entity);
            if (e == null) return NotFound();
            return Ok(e);
        }

        // POST: api/T
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var e = await Repository.Add(entity);
            if (e == null) return NotFound();
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity = await Repository.Delete(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }


    }
}