using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarroServico;

namespace CadastroDeCarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>();

        [HttpGet]

        public IActionResult Get()
        {
            return Ok(carros);
        }

        [HttpPost]
        public IActionResult Post (Carro carro)
        {
            CarroService carroService = new CarroService();

            string retorno = carroService.ValidarCarro(carro);
            {
                if (retorno != "Sucesso")
                {
                    return BadRequest(retorno);
                }
            }
            return Ok(retorno);
        }

/*        [HttpPost]

        public IActionResult Post([FromBody] Carro carro)
        {
            if (string.IsNullOrWhiteSpace(carro.Nome))
                return BadRequest("Nome deve ser informado!");

            carro.Id = Guid.NewGuid();

            carros.Add(carro);
            return Created();
        }*
        [HttpPatch]
        public IActionResult Patch(Guid id, [FromBody] Carro carro)
        {
            if (carro == null)
                return BadRequest();

            if (GetById(id) == null)
                return NotFound();

            carros.First(x => x.Id == id).Nome = carro.Nome;
            carros.First(x => x.Id == id).Marca = carro.Marca;
            carros.First(x => x.Id == id).Modelo = carro.Modelo;
            carros.First(x => x.Id == id).Cor = carro.Cor;
            carros.First(x => x.Id == id).Ano = carro.Ano;
            return Ok(carro);
        }
        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var obj = GetById(id);
            if (obj == null)
                return NotFound();

            carros.Remove(obj);
            return Ok();
        }
        [HttpGet("GetById")]
        private Carro GetById(Guid Id)
        {
            return carros.FirstOrDefault(x => x.Id == Id);
        }*/
    }
}
