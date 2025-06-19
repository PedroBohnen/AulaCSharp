using CadastroDeAlunos;

var pessoas = new List<Pessoa>();

string opcao = string.Empty;

while (opcao != "4")
{
    Console.WriteLine("===============================");
    Console.WriteLine("====== ESCOLHA UMA OPÇÃO ======");
    Console.WriteLine("===============================");
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1 - Cadastrar Pessoa");
    Console.WriteLine("2 - Listar pessoa pela inicial do nome");
    Console.WriteLine("3 - Listar pessoa pelo nome ou idade");
    Console.WriteLine("4 - Listar pessoa pelo cpf");
    Console.WriteLine("5 - Remover Pessoa");
    Console.WriteLine("0 - Sair");

    Console.Write("Opção: ");

    opcao = Console.ReadLine();

    if (opcao == "0")
    {
        Console.WriteLine("Programa encerrado.");
        break;
    }

    if (opcao == "1")
    {
        Console.WriteLine("Digite o CPF do aluno (somente números)");
        string cpf = Console.ReadLine();

        bool cpfJaExiste = pessoas.Any(a => a.Cpf == cpf);

        if (cpfJaExiste)
        {
            Console.WriteLine($"O cpf {cpf} já exite na base.");
            break;
        }
        Console.Write("Digite um nome: ");
        string nome = Console.ReadLine();

        Console.Write("Digite sua idade: ");
        string idadeInput = Console.ReadLine();

        if (!int.TryParse(idadeInput, out int idade))
        {
            Console.WriteLine("Idade inválida.");
            return;
        }

        var pessoa = new Pessoa
        {
            Nome = nome,
            Cpf = cpf,
            Idade = idade,
            Matricula = Guid.NewGuid()
        };

        pessoas.Add(pessoa);

        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"CPF: {pessoa.Cpf}");
        Console.WriteLine($"Idade: {pessoa.Idade}");
        Console.WriteLine($"Matricula: {pessoa.Matricula}");
    }
    else if (opcao == "2")
    {
        Console.WriteLine("Digite a letra inicial da pessoa: ");
        string letraInicial = Console.ReadLine();

        if(letraInicial.Length != 1)
        {
            Console.WriteLine("Por favor, digite apenas uma letra.");
            return;
        }

        var pessoasFiltradas = pessoas.Where(p => p.Nome.StartsWith(letraInicial, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!pessoasFiltradas.Any())
        {
            Console.WriteLine($"Nenhuma pessoa encontrada com a letra inicial '{letraInicial}'.");
            return;
        }

        var pessoasResponse = pessoasFiltradas.Select(a => new PessoaResponse
        {
            Nome = a.Nome,
            Idade = a.Idade,
        });

        Console.WriteLine($"Pessoas encontradas com a letra inicial '{letraInicial}':");

            
            foreach (var pessoa in pessoasResponse)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}");
                Console.WriteLine($"Idade: {pessoa.Idade}");
            }
        }
    else if (opcao == "3")
    {
        Console.WriteLine("Digite o 1- nome ou  2- idade da pessoa: ");
        string escolha = Console.ReadLine();


        List<Pessoa> ordenados;
        if (escolha == "1")
        {
            ordenados = pessoas.OrderBy(a => a.Nome).ToList();
        }
        else if (escolha == "2")
        {
            ordenados = pessoas.OrderBy(a => a.Idade).ToList();
        }
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        var pessoasResponse = ordenados.Select(a => new PessoaResponse
        {
            Nome = a.Nome,
            Idade = a.Idade,
        });

        Console.WriteLine($"Pessoas ordenadas:");


        foreach (var pessoa in pessoasResponse)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Idade: {pessoa.Idade}");
        }
    } else if (opcao == "4"){

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            var aluno = pessoas.FirstOrDefault(a => a.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            var pessoaDetalhadoResponse = new PessoaResponse2
            {
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                Cpf = aluno.Cpf,
                Matricula = aluno.Matricula
            };

            Console.WriteLine($"- Nome: {pessoaDetalhadoResponse.Nome}");
            Console.WriteLine($"- Idade: {pessoaDetalhadoResponse.Idade}");
            Console.WriteLine($"- Cpf: {pessoaDetalhadoResponse.Cpf}");
            Console.WriteLine($"- Matricula: {pessoaDetalhadoResponse.Matricula}");
    }

    else if (opcao == "5")
    {
        Console.Write("Digite um cpf: ");
        string cpf = Console.ReadLine();

        var pessoa = pessoas.Find(a => a.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase));

        if (pessoa != null)
        {
            pessoas.Remove(pessoa);
            Console.WriteLine($"Nome {pessoa.Nome} removido.");
        }
        else
        {
            Console.WriteLine($"Nome {pessoa.Nome} não encontrado.");
        }
    }
}


// FORMA DIFERENTE DE FAZER 

//using CadastroDeAlunos;

//var alunos = new List<Pessoa>();

//bool deveContinuar = true;

//while (deveContinuar)
//{
//    Console.WriteLine("Bem vindo ao cadstro de alunos!");
//    Console.WriteLine("\nEscolha uma opção abaixo");
//    Console.WriteLine("1 - Cadastrar Pessoa");
//    Console.WriteLine("2 - Remover Pessoa");
//    Console.WriteLine("3 - Listar Pessoa");
//    Console.WriteLine("0 - Sair");

//    string opcao = Console.ReadLine();

//    switch (opcao)
//    {
//        case "1":

//            Console.WriteLine("Digite o CPF do aluno (somente números)");
//            string cpfAlunoAdicionar = Console.ReadLine();

//            bool cpfJaExiste = alunos.Any(a => a.Cpf == cpfAlunoAdicionar);

//            if(cpfJaExiste)
//            {
//                Console.WriteLine($"O cpf {cpfAlunoAdicionar} já exite na base.");
//                break;
//            }

//            Console.WriteLine("Digite o nome do aluno");
//            string nomeAlunoAdicionar = Console.ReadLine();
//            Console.WriteLine("Digite o idade do aluno");
//            string idadeAlunoAdicionar = Console.ReadLine();
//            int idadeInt = int.Parse(idadeAlunoAdicionar);

//            var aluno = new Pessoa
//            {
//                Nome = nomeAlunoAdicionar,
//                Cpf = cpfAlunoAdicionar,
//                Idade = idadeInt
//            }
//            ;

//            break;

//        case "2":
//            Console.WriteLine("Digite o nome do aluno a ser removido");
//            string nomeAlunoRemover = Console.ReadLine();

//            //bool isAlunoRemovido = alunos.Remove(nomeAlunoRemover);

//            string aluno = alunos.Find(a => a.Equals(nomeAlunoRemover, StringComparison.OrdinalIgnoreCase));

//            if (aluno != null)
//            {
//                alunos.Remove(nomeAlunoRemover);
//                Console.WriteLine($"Aluno {nomeAlunoRemover} foi removido.");
//            }
//            else
//            {
//                Console.WriteLine($"Aluno {nomeAlunoRemover} não foi encontrado.");
//            }

//            //if(isAlunoRemovido)
//            //    Console.WriteLine($"Aluno {nomeAlunoRemover} foi removido.");
//            //else
//            //    Console.WriteLine($"Aluno{nomeAlunoRemover} não foi encontrado.");

//            break;

//        case "3":
//            Console.WriteLine("\n------Lista de alunos------");
//            foreach (var nomeAluno in alunos)
//            {
//                Console.WriteLine($"Aluno - {nomeAluno}");
//            }
//            break;

//        case "0":
//            deveContinuar = false;
//            break;

//        default:
//            Console.WriteLine("Opção não é válida!");
//            break;
//    }
//}

