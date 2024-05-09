using Knight.API.Models;
using Knight.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Knight.API.Controllers
{
    [Route("apiknight")]
    public class KnightsController : Controller
    {
        private readonly IKnightRepository _repository;

        public KnightsController(IKnightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Knights>>> Get()
        {
            var knights = await _repository.GetAll();
            var a = Newtonsoft.Json.JsonConvert.SerializeObject(knights);
            return Ok(a);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Knights>> GetById(string id)
        {
            var knight = await _repository.GetById(id);
            if (knight == null)
            {
                return NotFound();
            }
            return Ok(knight);
        }

        /// <summary>
        /// Cria
        /// </summary>
        /// <param name="knight"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<Knights>> Create([FromBody] Knights knight)
        {
            await _repository.Create(knight);
            return Ok(knight);
            //return CreatedAtAction(nameof(GetById), new { id = knight.Id }, knight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Knights knight)
        {
            var existingKnight = await _repository.GetById(id);
            if (existingKnight == null)
            {
                return NotFound();
            }

            knight.Id = existingKnight.Id;
            await _repository.Update(id, knight);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingKnight = await _repository.GetById(id);
            if (existingKnight == null)
            {
                return NotFound();
            }

            await _repository.Delete(id);
            return NoContent();
        }
    }
}
