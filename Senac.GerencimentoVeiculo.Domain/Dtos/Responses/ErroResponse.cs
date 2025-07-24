﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senac.GerencimentoVeiculo.Domain.Dtos.Responses
{
    public class ErroResponse
    {
        public string Mensagem { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Codigo { get; set; }
    }
}
