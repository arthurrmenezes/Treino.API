using Microsoft.EntityFrameworkCore;
using Treino.API.Services;
using TreinoAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TreinoContext>(options =>
    options.UseNpgsql(connectionString));

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
