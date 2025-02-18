using Treino.API.Endpoints;
using TreinoAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TreinoContext>();
builder.Services.AddTransient<TreinoDAL>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndpointsTreinos();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
