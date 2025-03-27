using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TreinoApp.API.Services;
using TreinoApp.Infrastructure.Data;

namespace TreinoApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ApplyInfrastructureDependenciesConfiguration(
        this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

        serviceCollection.AddScoped<TreinoRepository, TreinoRepository>();

        return serviceCollection;
    }
}
