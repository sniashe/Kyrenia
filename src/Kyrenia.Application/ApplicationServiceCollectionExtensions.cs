using Kyrenia.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kyrenia.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ITitleService, TitleService>();

        return services;
    }
}
