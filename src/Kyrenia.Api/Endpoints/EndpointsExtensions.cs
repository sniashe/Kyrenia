using Kyrenia.Api.Endpoints.Titles;

namespace Kyrenia.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapTitleEndpoints();

        return app;
    }
}
