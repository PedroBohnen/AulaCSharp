using Microsoft.AspNetCore.Hosting.Server;
using Senac.GerenciamentoVeiculo.Infra.Data.DataBaseConfiguration;
using Senac.GerenciamentoVeiculo.Infra.Data.Repositories;
using Senac.GerencimentoVeiculo.Domain.Repositories;
using Senac.GerencimentoVeiculo.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnectionFactory>(x =>
{
    return new DbConnectionFactory("Server = (localdb)\\MSSQLLocalDB; Database = gerenciamento_veiculo; Trusted_Connection = True; ");
});



builder.Services.AddScoped<ICarroService, CarroService>(); 
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
