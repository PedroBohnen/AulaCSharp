using Senac.LocaGames.Domain.Repositories;
using Senac.LocaGames.Domain.Services;
using Senac.LocaGames.Infra.Data.DataBaseConfiguration;
using Senac.LocaGames.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IDbConnectionFactory>(a =>
    new DbConnectionFactory(
        "Server = (localdb)\\MSSQLLocalDB; Database = loca_games; Trusted_Connection = True; ")
    );


builder.Services.AddScoped<IJogoService, JogoService>();
builder.Services.AddScoped<IJogoRepository, JogoRepository>();
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
