using TreinoAPI.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TreinoContext>();
builder.Services.AddTransient<TreinoDAL>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
