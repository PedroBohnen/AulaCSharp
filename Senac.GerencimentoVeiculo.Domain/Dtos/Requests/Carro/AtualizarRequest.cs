using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.GerencimentoVeiculo.Domain.Dtos.Requests.Carro
{
    public class AtualizarRequest
    {
        public string Placa { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
    }
}