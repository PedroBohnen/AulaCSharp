namespace Projeto_Pedro.Conta
{
    public class ContaBancaria
    {
        // Propriedades
        public string NumeroConta { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Saldo { get; private set; }

        // Construtor
        public ContaBancaria(string numeroConta, DateTime dataNascimento, decimal saldoInicial = 0)
        {
            NumeroConta = numeroConta;
            DataNascimento = dataNascimento;
            Saldo = saldoInicial;
        }

        // Métodos
        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Valor de depósito deve ser maior que zero.");
            }
        }

        public void Sacar(decimal valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Saque não permitido. Verifique o valor ou o saldo disponível.");
            }
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo atual: {Saldo:C}");
        }
    }
}
