//Calculadora calculadora = new Calculadora();

//string opcao = string.Empty;

//while (opcao != "5")
//{
//    Console.WriteLine("\nEscolha uma operação:");
//    Console.WriteLine("1 - Somar");
//    Console.WriteLine("2 - Subtrair");
//    Console.WriteLine("3 - Multiplicar");
//    Console.WriteLine("4 - Dividir");
//    Console.WriteLine("5 - Sair");
//    Console.Write("Opção: ");

//    opcao = Console.ReadLine();

//    if (opcao == "5")
//    {
//        Console.WriteLine("Programa encerrado.");
//        break;
//    }

//    Console.Write("Digite o primeiro número: ");
//    calculadora.Numero1 = Convert.ToDouble(Console.ReadLine());

//    Console.Write("Digite o segundo número: ");
//    calculadora.Numero2 = Convert.ToDouble(Console.ReadLine());

//    switch (opcao)
//    {
//        case "1":
//            Console.WriteLine($"Resultado da soma: {calculadora.Somar()}");
//            break;
//        case "2":
//            Console.WriteLine($"Resultado da subtração: {calculadora.Subtrair()}");
//            break;
//        case "3":
//            Console.WriteLine($"Resultado da multiplicação: {calculadora.Multiplicar()}");
//            break;
//        case "4":
//            Console.WriteLine($"Resultado da divisão: {calculadora.Dividir()}");
//            break;
//        default:
//            Console.WriteLine("Opção inválida. Tente novamente.");
//            break;
//    }
//}

//OUTRA FORMA DE FAZER 
//PARA FAZER DESTA FORMA TERIA QUE USAR "DECIMAL" AO INVES DE "DOUBLE"

using Calculadora;

while (true)
{
    var calculadora = new Calculadora();

    Console.WriteLine($"Bem vindo a calculadora interativa. Para continuar, digite qualquer tecla. Para sair digite {}");

    string inputInicial = Console.ReadLine();
    if (inputInicial == Constantes.SAIR)
    {
        break;
    }

    decimal valor1 = 0;
    decimal valor2 = 0;
    bool valoresValidos = false;

    try
    {
        Console.WriteLine("Digite o valor 1");
        string valor1Input = Console.ReadLine();
        valor1 = decimal.Parse(valor1Input);
        calculadora.Numero1 = valor1;

        Console.WriteLine("Digite o valor 2");
        string valor2Input = Console.ReadLine();
        valor2 = decimal.Parse(valor2Input);
        calculadora.Numero2 = valor2;

        valoresValidos = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Valor inválido. Por favor digite um valor numerico");
    }

    if(valoresValidos)
    {
        Console.WriteLine("Digite a operação desejada: 1 - soma; 2 - subtração; 3 - multiplicação; 4 - divisão");
        string operacao = Console.ReadLine();

        decimal resultado = 0;

        if(operacao == "1")
        {
            resultado = calculadora.Somar();
            ExibirResultado(resultado, nameof(Calculadora.Somar));

        }
        else if (operacao == "2")
        {
            resultado = calculadora.Subtrair();
            ExibirResultado(resultado, nameof(Calculadora.Subtrair));
        }
        else if (operacao == "3")
        {
            resultado = calculadora.Multiplicar();
            ExibirResultado(resultado, nameof(Calculadora.Multiplicar));
        }
        else if (operacao == "4")
        {
            resultado = calculadora.Dividir();
            ExibirResultado(resultado, nameof(Calculadora.Dividir));
        }
        else
        {
            Console.WriteLine("Operação escolhida inválida");
            continue;
        }
    }
}

static void ExibirResultado(decimal resultado, string operacao)
{
    Console.WriteLine($"O resultado da operação {operacao} é: {resultado}");
}
