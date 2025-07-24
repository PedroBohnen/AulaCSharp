using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.GerencimentoVeiculo.Domain.Dtos.Requests.Carro;
using Senac.GerencimentoVeiculo.Domain.Dtos.Responses.Carro;
using Senac.GerencimentoVeiculo.Domain.Models;
using Senac.GerencimentoVeiculo.Domain.Repositories;


namespace Senac.GerencimentoVeiculo.Domain.Services
{
    public class CarroService : ICarroService
    {

        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task AtualizarPorId(long id, AtualizarRequest atualizarRequest)
        {
            bool isTipoCombustivelValido = Enum.TryParse(atualizarRequest.TipoCombustivel, true, out TipoCombustivelCarro tipoCombustivel);

            if (!isTipoCombustivelValido)
            {
                throw new Exception($"O tipo de combustível '{atualizarRequest.TipoCombustivel}' é invalido.");
            }

            var carro = await _carroRepository.ObterDetlhadoPorId(id);

            if (carro == null)
            {
                throw new Exception($"Não foi encontrado um carro com o ID {id}.");
            }

            carro.Placa = atualizarRequest.Placa;
            carro.Cor = atualizarRequest.Cor;
            carro.TipoCombustivel = tipoCombustivel;

            await _carroRepository.AtualizarPorId(carro);
        }

        public async Task<CadastrarResponse> Cadastrar(CadastrarRequest cadastrarRequest)
        {

            bool isTipoCombustivelValido = Enum.TryParse(cadastrarRequest.TipoCombustivel, true, out TipoCombustivelCarro tipoCombustivel);

            if (!isTipoCombustivelValido)
            {
                throw new Exception($"O tipo de combustível '{cadastrarRequest.TipoCombustivel}' é invalido.");
            }

            var carro = new Carro
            {
                AnoFabricacao = cadastrarRequest.AnoFabricacao,
                Cor = cadastrarRequest.Cor,
                Marca = cadastrarRequest.Marca,
                Nome = cadastrarRequest.Nome,
                Placa = cadastrarRequest.Placa,
                TipoCombustivel = tipoCombustivel
            };

            long idResponse = await _carroRepository.Cadastrar(carro);

            var response = new CadastrarResponse
            {
                Id = idResponse,
            };

            return response;
        }

        public async Task DeletarPorId(long id)
        {

            var carro = await _carroRepository.ObterDetlhadoPorId(id);

            if (carro == null)
            {
                throw new Exception($"Não foi encontrado um carro com o ID {id}.");
            }

            await _carroRepository.DeletarPorId(id);
        }

        public async Task<ObterDetlhadoPorIdResponses> ObterDetlhadoPorId(long id)
        {
            var carro = await _carroRepository.ObterDetlhadoPorId(id);

            if (carro == null)
            {
                throw new Exception($"Não foi encontrado um carro com o ID {id}.");
            }

            var carroResponse = new ObterDetlhadoPorIdResponses
            {
                Id = carro.Id,
                Nome = carro.Nome,
                AnoFabricacao = carro.AnoFabricacao,
                Cor = carro.Cor,
                Marca = carro.Marca,
                Placa = carro.Placa,
                TipoCombustivel = carro.TipoCombustivel.ToString()
            };

            return carroResponse;
        }

        public async Task<IEnumerable<ObterTodosResponses>> ObterTodos()
        {
            var carros = await _carroRepository.ObterTodos();



            var carroResponse =  carros.Select(c => new ObterTodosResponses
            {
                Nome = c.Nome,
                Id = c.Id
            });

            return carroResponse;

        }


    }
}
