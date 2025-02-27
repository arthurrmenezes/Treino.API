using Treino.API.Services;
using TreinoAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TreinoContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<TreinoService, TreinoService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
