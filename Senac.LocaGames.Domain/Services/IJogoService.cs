using Senac.LocaGames.Domain.Dtos.Requests;
using Senac.LocaGames.Domain.Dtos.Responses;

namespace Senac.LocaGames.Domain.Services;

public interface IJogoService
{
    Task<CadastrarResponse>Cadastrar(CadastrarRequest cadastrarRequest);
    Task<IEnumerable<ObterTodosReponse>> ObterTodos();
    Task<ObterDetalhadoPorIdReponse> ObterDetlhadoPorId(long id);
    Task DeletarPorId(long id);
    Task AtualizarPorId(long id, AtualizarRequest atualizarRequest);
    Task<AlugarRequest> Alugar(long id, AlugarRequest alugarRequest);
    Task Devolver(long id);
}
