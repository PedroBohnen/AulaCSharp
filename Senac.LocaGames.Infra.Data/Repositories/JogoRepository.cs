using Dapper;
using Senac.LocaGames.Domain.Models;
using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Infra.Data.DataBaseConfiguration;

namespace Senac.LocaGames.Infra.Data.Repositories;

public class JogoRepository : IJogoRepository
{

    private readonly IDbConnectionFactory _connectionFactory;
    public JogoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task Alugar(Jogo jogo)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"  
                UPDATE
                    jogos
                SET
                    disponivel = @disponivel,
                    responsavel = @Responsavel,
                    dataEntrega = @DataEntrega
                WHERE
                    id = @Id",
                jogo);
    }

    public async Task AtualizarPorId(long id, Jogo jogo)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                UPDATE
                    jogos
                SET
                    titulo = @Titulo,
                    descricao = @Descricao,
                    categoria = @Categoria
                WHERE
                    id = @Id",
            jogo);
    }

    public async Task<long> Cadastrar(Jogo jogo)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<long>(
            @"
                INSERT INTO jogos
                    (titulo,
                    descricao,
                    categoria,
                    disponivel,
                    responsavel,
                    dataEntrega)
                OUTPUT INSERTED.id
                VALUES
                (
                     @Titulo,
                     @Descricao,
                     @Categoria,
                     @Disponivel,
                     @Responsavel,
                     @DataEntrega
                )",
            jogo);
    }

    public async Task DeletarPorId(long id)
    {
        await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                DELETE 
                FROM
                    jogos
                WHERE 
                    id = @Id",
            new
            { 
                Id = id 
            });
    }

    public Task Devolver(long id)
    {
        return _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync(
            @"
                UPDATE
                    jogos
                SET
                    disponivel = 1,
                    responsavel = NULL,
                    dataEntrega = NULL
                WHERE
                    id = @Id",
            new { Id = id });
    }

    public async Task<Jogo> ObterDetlhadoPorId(long id)
    {
        return await _connectionFactory.CreateConnection()
            .QueryFirstOrDefaultAsync<Jogo>(
            @"
                SELECT
                    j.id,
                    j.titulo,
                    j.descricao,
                    t.Id AS Categoria,
                    j.disponivel,
                    j.responsavel,
                    j.dataEntrega
                FROM
                    jogos j
                INNER JOIN
                    TipoCategoria t ON t.Id = j.Categoria
                WHERE
                    j.id = @Id",
            new
            {
                Id = id
            });
    }

    public async Task<IEnumerable<Jogo>> ObterTodos()
    {
        return await _connectionFactory.CreateConnection()
            .QueryAsync<Jogo>(
            @"
                SELECT
                    j.id,
                    j.titulo,
                    t.Id AS Categoria,
                    j.disponivel,
                    j.dataEntrega
                FROM
                    jogos j
                INNER JOIN
                    TipoCategoria t ON t.Id = j.Categoria
            ");
    }
}
