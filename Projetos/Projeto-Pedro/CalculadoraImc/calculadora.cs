namespace Projeto_Pedro.CalculadoraImc
{
    public class Calculadora
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public double Calculo { get; private set; }
        public void CalcularImc()
        {
            Calculo = Peso / (Altura * Altura);
        }
    }
}
