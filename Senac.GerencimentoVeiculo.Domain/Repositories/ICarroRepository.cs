using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.GerencimentoVeiculo.Domain.Models;

namespace Senac.GerencimentoVeiculo.Domain.Repositories
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> ObterTodos();
        Task<Carro> ObterDetlhadoPorId(long id);
        Task<long> Cadastrar(Carro carro);
        Task DeletarPorId(long id);
        Task AtualizarPorId(Carro carro);
    }
}
