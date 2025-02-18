using Treino.API.Endpoints;
using TreinoAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TreinoContext>();
builder.Services.AddTransient<TreinoDAL>();

var app = builder.Build();

app.AddEndpointsTreinos();

app.Run();
