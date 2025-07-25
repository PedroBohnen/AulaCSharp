﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senac.GerencimentoVeiculo.Domain.Models;

namespace Senac.GerencimentoVeiculo.Domain.Dtos.Requests.Carro
{
    public class CadastrarRequest
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public string TipoCombustivel { get; set; }
    }
}
