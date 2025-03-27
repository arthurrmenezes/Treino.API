using TreinoApp.API.Services;
using TreinoApp.Application;
using TreinoApp.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.ApplyApplicationDependenciesConfiguration();
        builder.Services.ApplyInfrastructureDependenciesConfiguration(connectionString!);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<TreinoRepository, TreinoRepository>();
        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }
}