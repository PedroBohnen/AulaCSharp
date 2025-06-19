
using Projeto_Pedro.Conta;

class Program
{
    static void Main(string[] args)
    {
        // Coletando dados do usuário
        Console.Write("Digite o número da conta: ");
        string numeroConta = Console.ReadLine();

        Console.Write("Digite a sua data de nascimento: ");
        DateTime dataNascimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        // Criando a conta bancária
        ContaBancaria conta = new ContaBancaria(numeroConta, dataNascimento);

        // Operações bancárias
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nEscolha uma operação:");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Consultar Saldo");
            Console.WriteLine("4 - Sair");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o valor para depósito: ");
                    decimal deposito = decimal.Parse(Console.ReadLine());
                    conta.Depositar(deposito);
                    break;
                case "2":
                    Console.Write("Digite o valor para saque: ");
                    decimal saque = decimal.Parse(Console.ReadLine());
                    conta.Sacar(saque);
                    break;
                case "3":
                    conta.ConsultarSaldo();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        Console.WriteLine("Obrigado por usar nosso banco!");
    }
}
