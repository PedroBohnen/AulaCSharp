using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Senac.GerenciamentoVeiculo.Infra.Data.DataBaseConfiguration;
using Senac.GerencimentoVeiculo.Domain.Models;
using Senac.GerencimentoVeiculo.Domain.Repositories;

namespace Senac.GerenciamentoVeiculo.Infra.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
            private readonly IDbConnectionFactory _connectionFactory;

            public MotoRepository(IDbConnectionFactory connectionFactory)
            {
                _connectionFactory = connectionFactory;
            }

            public async Task AtualizarPorId(Moto moto)
            {
                await _connectionFactory.CreateConnection()
                    .QueryFirstOrDefaultAsync(
                    @"
                UPDATE
                    carro
                SET
                    placa = @Placa,
                    cor = @Cor,
                    tipoCombustivelId = @TipoCombustivel
                WHERE
                    id = @Id
     
                ",
                    moto);

            }

            public async Task<long> Cadastrar(Carro carro)
            {
                return await _connectionFactory.CreateConnection()
                    .QueryFirstOrDefaultAsync<long>(
                    @"


                INSERT INTO carro
                   (nome
                   ,marca
                   ,placa
                   ,cor
                   ,anoFabricacao
                   ,tipoCombustivelId
                )
                OUTPUT INSERTED.id
                VALUES
                (
                    @Nome, 
                    @Marca, 
                    @Placa, 
                    @Cor, 
                    @AnoFabricacao, 
                    @TipoCombustivel
                )
                 
                ",
                    carro);
            }

            public async Task DeletarPorId(long id)
            {
                await _connectionFactory.CreateConnection()
                     .QueryFirstOrDefaultAsync(
                     @"
            DELETE 
            FROM carro 
            WHERE Id = @Id",
                     new
                     {
                         Id = id
                     });
            }

            public async Task<Carro> ObterDetlhadoPorId(long id)
            {
                return await _connectionFactory.CreateConnection()
                    .QueryFirstOrDefaultAsync<Carro>(
                    @"
            SELECT
                c.id,
                c.nome,
                c.marca,
                c.cor,
                c.placa,
                c.anoFabricacao,
                t.Id AS TipoCombustivel
            FROM
                carro c
            INNER JOIN
                TipoCombustivel t ON t.Id = c.TipoCombustivelId
            WHERE 
                c.Id = @Id",
                    new
                    {
                        Id = id
                    });
            }

            public async Task<IEnumerable<Carro>> ObterTodos()
            {
                return await _connectionFactory.CreateConnection()
                    .QueryAsync<Carro>(
                    @" 
                SELECT id,
                    nome
                FROM carro
                ");


            }
        }
    }

