// See https://aka.ms/new-console-template for more information
using AulaRevisao;
using AulaRevisao.Polimorfismo;

//ABSTRACAO INICIO

//var pessoa = new Pessoa();
//pessoa.Nome = "Pedro";
//pessoa.DataDeNascimento = new DateTime(2007, 09, 11);

//bool isMaiorDeIdade = pessoa.IsMaiorDeIdade;
//string resultadoMaiorDeIdade = isMaiorDeIdade ? "Sim" : "Não";

//Console.WriteLine($"A pessoa {pessoa.Nome} é maior de idade? {resultadoMaiorDeIdade}");


//pessoa.FalarNome();

//string nome = pessoa.RetornarNome();
//Console.WriteLine($"O nome da pessoa é: {nome}");

//ABSTRACAO FIM

//POLIMORFISMO INICIO

//Animal gato = new Gato();
//Animal cachorro = new Cachorro();

//Console.WriteLine($"fala do gato");
//gato.Falar();

//Console.WriteLine($"fala do cachorro");
//cachorro.Falar();

//gato.Caminhar();
//cachorro.Caminhar();

//POLIMORFISMO FIM

//ENCAPSULAMENTO INICIO

var cachorro = new Cachorro("Rex");

cachorro.Nome = "A";

Console.WriteLine($"O nome do cachorro é: {cachorro.Nome}");