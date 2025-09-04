using Kyrenia.Application.Providers;
using Kyrenia.Infrastructure.Providers.Omdb;
using Microsoft.Extensions.DependencyInjection;

namespace Kyrenia.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<ITitleProvider, OmdbTitleProvider>();

        return services;
    }
}
