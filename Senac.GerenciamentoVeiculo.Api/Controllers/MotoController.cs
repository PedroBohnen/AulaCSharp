using Microsoft.AspNetCore.Mvc;
using Senac.GerencimentoVeiculo.Domain.Dtos.Requests.Carro;
using Senac.GerencimentoVeiculo.Domain.Dtos.Responses;
using Senac.GerencimentoVeiculo.Domain.Services;

namespace Senac.GerenciamentoVeiculo.Api.Controllers
{

    [ApiController]
    [Route("moto")]

    public class MotoController : Controller
    {
        
        private readonly ICarroService _carroService;

        public MotoController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var carrosResponse = await _carroService.ObterTodos();

            return Ok(carrosResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDetlhadoPorId([FromRoute] long id)
        {
            try
            {
                var carroDetalhadoResponse = await _carroService.ObterDetlhadoPorId(id);

                return Ok(carroDetalhadoResponse);
            }
            catch (Exception ex)
            {
                var erroResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                };
                return NotFound(erroResponse);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] CadastrarRequest cadastrarRequest)
        {

            try
            {

                var cadastrarResponse = await _carroService.Cadastrar(cadastrarRequest);

                return Ok(cadastrarResponse);
            }
            catch (Exception ex)
            {
                var erroResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                };

                return BadRequest(erroResponse);
            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletarPorId([FromRoute] long id)
        {
            try
            {
                await _carroService.DeletarPorId(id);

                return Ok();
            }
            catch (Exception ex)
            {
                var erroResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                };

                return BadRequest(erroResponse);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPorId([FromRoute] long id, [FromBody] AtualizarRequest atualizarRequest)
        {
            try
            {
                await _carroService.AtualizarPorId(id, atualizarRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                var erroResponse = new ErroResponse
                {
                    Mensagem = ex.Message,
                };

                return BadRequest(erroResponse);
            }
        }
    }
}
