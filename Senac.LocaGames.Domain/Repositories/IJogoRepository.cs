using Senac.LocaGames.Domain.Models;

namespace Senac.LocaGames.Domain.Repositories;

public interface IJogoRepository
{
    Task<IEnumerable<Jogo>> ObterTodos();
    Task<Jogo> ObterDetlhadoPorId(long id);
    Task<long> Cadastrar(Jogo jogo);
    Task DeletarPorId(long id);
    Task AtualizarPorId(long id, Jogo jogo);
    Task Devolver(long id);
    Task Alugar(Jogo jogo);
}
