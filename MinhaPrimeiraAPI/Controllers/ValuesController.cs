using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(pessoas);
        }

        [HttpPost]

        public IActionResult Post([FromBody]Pessoa pessoa)
        {
            if (string.IsNullOrWhiteSpace(pessoa.Nome))
                return BadRequest("Nome deve ser informado!");

            pessoa.Id = Guid.NewGuid();

            pessoas.Add(pessoa);
                return Created();
        }
        [HttpPatch]
        public IActionResult Patch(Guid id,[FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest();

            if (GetById(id) == null)
                return NotFound();

            pessoas.First(x => x.Id == id).Nome = pessoa.Nome;
            return Ok(pessoa);
        }
        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var obj = GetById(id);
            if (obj == null)
                return NotFound();

            pessoas.Remove(obj);
            return Ok();
        }
        [HttpGet("GetById")]
        private Pessoa GetById (Guid Id)
        {
            return pessoas.FirstOrDefault(x => x.Id == Id);
        }
    }
}
