namespace Kyrenia.Infrastructure.Providers.Omdb;

internal class OmdbTitleSummary
{
    public required string Title { get; init; }

    public required string Year { get; init; }

    public required string ImdbID { get; init; }

    public required string Type { get; init; }

    public required string Poster { get; init; }
}
