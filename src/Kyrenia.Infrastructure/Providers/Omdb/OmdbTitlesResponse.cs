namespace Kyrenia.Infrastructure.Providers.Omdb;

internal class OmdbTitlesResponse
{
    public List<OmdbTitleSummary> Search { get; init; } = [];

    public required string TotalResults { get; init; }

    public required string Response { get; init; }
}
