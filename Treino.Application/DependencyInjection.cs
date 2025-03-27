using Microsoft.Extensions.DependencyInjection;
using TreinoApp.Application.Services.TreinoContext;

namespace TreinoApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection ApplyApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        serviceCollection.AddScoped<TreinoService, TreinoService>();

        return serviceCollection;
    }
}
