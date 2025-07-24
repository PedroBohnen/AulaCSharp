using Senac.GerencimentoVeiculo.Domain.Dtos.Requests.Carro;
using Senac.GerencimentoVeiculo.Domain.Dtos.Responses.Carro;
using Senac.GerencimentoVeiculo.Domain.Models;

namespace Senac.GerencimentoVeiculo.Domain.Services
{
    public interface ICarroService
    {
        Task <CadastrarResponse>Cadastrar(CadastrarRequest cadastrarRequest);
        Task<IEnumerable<ObterTodosResponses>> ObterTodos();
        Task<ObterDetlhadoPorIdResponses> ObterDetlhadoPorId(long id);
        Task DeletarPorId(long id);
        Task AtualizarPorId(long id, AtualizarRequest atualizarRequest);
    }
}
