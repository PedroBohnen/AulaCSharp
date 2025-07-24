
using System;
using CollectionsAndLink;

var pessoas = new List<Pessoa>
{
    new Pessoa
    {
        Nome = "João",
        Id = 1,
        DataNascimento = new DateTime(1990, 1, 1)
    },
    new Pessoa
    {
        Nome = "Maria",
        Id = 2,
        DataNascimento = new DateTime(1995, 5, 15)
    },
    new Pessoa
    {
        Nome = "Pedro",
        Id = 3,
        DataNascimento = new DateTime(1988, 3, 20)
    }
};


//buscar todas as pessoas
Console.WriteLine("---- Pessoas ----");
foreach (var pessoa in pessoas)
{
    Console.WriteLine($"Nome: {pessoa.Nome}, Id: {pessoa.Id}, Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
}


//pessoa com id maior que 1
var pessoasFiltradas = pessoas.Where(p => p.Id > 1);
Console.WriteLine("\n---- Pessoas Filtradas ----");
foreach (var pessoa in pessoasFiltradas)
{
    Console.WriteLine($"Nome: {pessoa.Nome}, Id: {pessoa.Id}, Data de Nascimento: {pessoa.DataNascimento.ToShortDateString()}");
}


//pessoa response com mapper
IEnumerable<PessoaResponse> pessoasResponse = pessoas.Select(p => new PessoaResponse
{
    Nome = p.Nome,
    Id = p.Id,
});
Console.WriteLine("\n---- Pessoas Response ----");
foreach (var pessoa in pessoasResponse)
{
    Console.WriteLine($"Nome: {pessoa.Nome}, Id: {pessoa.Id}");
}
// pessoas ordenadas por nome usando orderby    

var pessoasOrdenadas = pessoas.OrderBy(p => p.Nome);

Console.WriteLine("\n---- Pessoas ordenadas por nome ----");
foreach (var pessoa in pessoasResponse)
{
    Console.WriteLine($"Pessoa response {pessoa.Nome} - {pessoa.Id}");
}

//buscar 1 pessoa, com base em uma condição 
Pessoa pessoaBuscada = pessoas.FirstOrDefault(p => p.Nome == "Pedro");
if (pessoaBuscada == null)
{
    Console.WriteLine("Pessoa não encontrada");
}
else
{
    Console.WriteLine($"Pessoa encontrada: {pessoaBuscada.Nome}");
}
