using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRevisao.Emcapsulamento
{
    public class Cachorro
    {
        public Cachorro(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; private set; }

    }
}
