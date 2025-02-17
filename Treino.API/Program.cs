using Microsoft.AspNetCore.Mvc;
using TreinoAPI.DataBase;
using TreinoAPI.Modelos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<TreinoContext>();
builder.Services.AddTransient<TreinoDAL>();

app.MapGet("/Treinos", ([FromServices] TreinoDAL treinoDAL) =>
{
    var treino = treinoDAL.MostrarTodosOsTreinos();

    if (treino is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(treino);
});

app.MapPost("/Treinos", ([FromServices] TreinoDAL treinoDAL, [FromBody] TreinoModel treino) =>
{
    treinoDAL.AdicionarTreino(treino);
    return Results.Ok();
});

app.MapDelete("/Treinos", ([FromServices] TreinoDAL treinoDAL, int id) =>
{
    treinoDAL.RemoverTreino(id);
});

app.Run();
