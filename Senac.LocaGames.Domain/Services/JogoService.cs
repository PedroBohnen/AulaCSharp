using Senac.LocaGames.Domain.Dtos.Requests;
using Senac.LocaGames.Domain.Dtos.Responses;
using Senac.LocaGames.Domain.Models;
using Senac.LocaGames.Domain.Repositories;

namespace Senac.LocaGames.Domain.Services;

public class JogoService : IJogoService
{
    private readonly IJogoRepository _gameRepository;

    public JogoService(IJogoRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<CadastrarResponse> Cadastrar(CadastrarRequest cadastrarRequest)
    {
        bool isTipoCategoriaValido = Enum.TryParse(cadastrarRequest.Categoria, true, out TipoCategoria tipoCategoria);

        if (!isTipoCategoriaValido)
        {
            throw new Exception($"O tipo de categoria '{cadastrarRequest.Categoria}' é invalido.");
        }
        var novoJogo = new Jogo
        {
            Titulo = cadastrarRequest.Titulo,
            Descricao = cadastrarRequest.Descricao,
            Categoria = tipoCategoria,
            Disponivel = true,
            Responsavel = null,
            DataEntrega = null,
        };

        long idJogoResponse = await _gameRepository.Cadastrar(novoJogo);

        var jogoResponse = new CadastrarResponse
        {
            Id = idJogoResponse,
        };

        return jogoResponse;
    }

    public async Task<IEnumerable<ObterTodosReponse>> ObterTodos()
    {
        var jogos = await _gameRepository.ObterTodos();

        return jogos
            .OrderBy(x => x.Titulo)
            .Select(x => new ObterTodosReponse
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Categoria = x.Categoria.ToString(),
                Disponivel = x.Disponivel,
                DataEntrega = x.DataEntrega,
                IsEmAtraso = (x.DataEntrega != null && x.DataEntrega.Value.Date < DateTime.Now.Date)
            });
    }

    public async Task<ObterDetalhadoPorIdReponse> ObterDetlhadoPorId(long id)
    {
        var jogo = await _gameRepository.ObterDetlhadoPorId(id);
        if (jogo == null)
            throw new Exception("Jogo não encontrado.");

        return new ObterDetalhadoPorIdReponse
        {
            Id = jogo.Id,
            Titulo = jogo.Titulo,
            Descricao = jogo.Descricao,
            Categoria = jogo.Categoria.ToString(),
            Disponivel = jogo.Disponivel,
            Responsavel = jogo.Responsavel,
            DataEntrega = jogo.DataEntrega,
            IsEmAtraso = (jogo.DataEntrega != null && jogo.DataEntrega.Value.Date < DateTime.Now.Date)
        };
    }

    public async Task AtualizarPorId(long id, AtualizarRequest request)
    {
        bool isTipoCategoriaValido = Enum.TryParse(request.Categoria, true, out TipoCategoria tipoCategoria);

        if (!isTipoCategoriaValido)
        {
            throw new Exception($"O tipo de categoria '{request.Categoria}' é invalido.");
        }

        var jogo = await _gameRepository.ObterDetlhadoPorId(id);
        if (jogo == null)
            throw new Exception("Jogo não encontrado.");

        jogo.Titulo = request.Titulo;
        jogo.Descricao = request.Descricao;
        jogo.Categoria = tipoCategoria;

        await _gameRepository.AtualizarPorId(id, jogo);
    }

    public async Task DeletarPorId(long id)
    {
        var jogo = await _gameRepository.ObterDetlhadoPorId(id);
        if (jogo == null)
            throw new Exception("Jogo não encontrado.");

        if (!jogo.Disponivel)
            throw new Exception("Não é possível deletar um jogo que está alugado.");

        await _gameRepository.DeletarPorId(id);
    }

    public async Task<AlugarRequest> Alugar(long id, AlugarRequest alugarRequest)
    {
        var jogo = await _gameRepository.ObterDetlhadoPorId(id);
        if (jogo == null)
            throw new Exception("Jogo não encontrado.");

        if (!jogo.Disponivel)
            throw new Exception("Jogo já está alugado.");

        jogo.Disponivel = false;
        jogo.Responsavel = alugarRequest.Responsavel;
        jogo.DataEntrega = jogo.Categoria switch
        {
            TipoCategoria.BRONZE => DateTime.Now.AddDays(9),
            TipoCategoria.PRATA => DateTime.Now.AddDays(6),
            TipoCategoria.OURO => DateTime.Now.AddDays(3),
            _ => throw new Exception("Categoria inválida.")
        };

        await _gameRepository.Alugar(jogo);
        return alugarRequest;
    }

    public async Task Devolver(long id)
    {
        var jogo = await _gameRepository.ObterDetlhadoPorId(id);
        if (jogo == null)
            throw new Exception("Jogo não encontrado.");

        if (jogo.Disponivel)
            throw new Exception("Este jogo não está alugado.");

        jogo.Disponivel = true;
        jogo.Responsavel = null;
        jogo.DataEntrega = null;

        await _gameRepository.Devolver(id);
    }
}
