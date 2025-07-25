﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senac.GerencimentoVeiculo.Domain.Models
{
    public class Moto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public TipoCombustivelMoto TipoCombustivel { get; set; }
    }
}
