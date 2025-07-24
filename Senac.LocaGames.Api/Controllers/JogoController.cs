using Microsoft.AspNetCore.Mvc;
using Senac.LocaGames.Domain.Dtos;
using Senac.LocaGames.Domain.Dtos.Requests;
using Senac.LocaGames.Domain.Services;

namespace Senac.LocaGames.Api.Controllers;

[ApiController]
[Route("jogo")]
public class JogoController : ControllerBase
{
    private readonly IJogoService _gameService;

    public JogoController(IJogoService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    public async Task<IActionResult>Cadastrar([FromBody] CadastrarRequest cadastrarRequest)
    {
        try
        {
            var cadastrarResponse = await _gameService.Cadastrar(cadastrarRequest);
            return Ok(cadastrarResponse);
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message
            };
            return BadRequest(erroResponse);
        }
    }

    [HttpGet]
    public async Task<IActionResult>ObterTodos()
    {
            var jogoResponse = await _gameService.ObterTodos();
            return Ok(jogoResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult>ObterDetlhadoPorId([FromRoute] long id)
    {
        try
        {
            var jogoDetalhadoResponse = await _gameService.ObterDetlhadoPorId(id);
            return Ok(jogoDetalhadoResponse);
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

    [HttpPut("{id}")]
    public async Task<IActionResult>AtualizarPorId([FromRoute] long id, [FromBody] AtualizarRequest atulizarRequest)
    {
        try
        {
            await _gameService.AtualizarPorId(id, atulizarRequest);
            return Ok();
        }
        catch (Exception ex)
        {
            {
                var erroResponse = new ErroResponse
                {
                    Mensagem = ex.Message
                };
                return BadRequest(erroResponse);
            }
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult>DeletarPorId([FromRoute] long id)
    {
        try
        {
            await _gameService.DeletarPorId(id);
            return Ok();
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message
            };
            return BadRequest(erroResponse);
        }
    }

    [HttpPut("{id}/alugar")]
    public async Task<IActionResult>Alugar([FromRoute] long id, [FromBody] AlugarRequest request)
    {
        try
        {
            await _gameService.Alugar(id, request);
            return Ok();
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message
            };
            return BadRequest(erroResponse);
        }
    }

    [HttpPut("{id}/devolver")]
    public async Task<IActionResult>Devolver([FromRoute] long id)
    {
        try
        {
            await _gameService.Devolver(id);
            return Ok();
        }
        catch (Exception ex)
        {
            var erroResponse = new ErroResponse
            {
                Mensagem = ex.Message
            };
            return BadRequest(erroResponse);
        }
    }
}
