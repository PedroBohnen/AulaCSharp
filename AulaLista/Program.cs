using AulaLista;

var pessoas = new List<Pessoa>(); // Corrigido para usar a classe Pessoa em vez de string
var pessoaUm = new Pessoa();
pessoaUm.Nome = "João";

pessoas.Add(pessoaUm);

foreach (var pessoa in pessoas)
{
    Console.WriteLine($"O nome é {pessoa.Nome}");
}

var nomes = new List<string>();

string nomeUm = "João";
string nomeDois = "Maria";
string nomeTres = "Pedro";

nomes.Add(nomeUm);
nomes.Add(nomeDois);
nomes.Add(nomeTres);

foreach (var nome in nomes)
{
    Console.WriteLine($"O nome é {nome}");
}

nomes.Remove(nomeUm);

int indiceEverton = nomes.IndexOf(nomeDois);
Console.WriteLine($"Indice do Everton {indiceEverton}");
nomes.RemoveAt(indiceEverton);

Console.WriteLine();
Console.WriteLine("Nova lista");
foreach (var nome in nomes)
{
    Console.WriteLine($"O nome é {nome}");
}
