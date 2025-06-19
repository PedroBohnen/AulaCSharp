public class Calculadora
    {
        
        public double Numero1 { get; set; }

        public double Numero2 { get; set; }

        public double Somar()
        {
            return Numero1 + Numero2;
        }

        public double Subtrair()
        {
            return Numero1 - Numero2;
        }
        public double Multiplicar()
        {
            return Numero1 * Numero2;
        }
        public double Dividir()
        {
            return Numero1 / Numero2;
        }
    }

