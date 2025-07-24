using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Pedro.media
{
    public class Aluno : Pessoa
    {
        public double Nota1 {  get; set; }
        public double Nota2 { get; set; }
        public double Media { get; private set; }
        public void CalcularMedia()
        {
            Media = (Nota1 +  Nota2) / 2;
        }
    }
}
