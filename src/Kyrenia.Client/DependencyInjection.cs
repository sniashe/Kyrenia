using Kyrenia.Client.Configuration;
using Kyrenia.Client.Services;

namespace Kyrenia.Client;

internal static class DependencyInjection
{
    public static IServiceCollection AddClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MediaServiceOptions>(
            configuration.GetSection(MediaServiceOptions.SectionName));

        services.AddHttpClient<IMediaService, MediaService>();

        return services;
    }
}
