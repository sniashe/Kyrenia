namespace Kyrenia.Application.Models;

public class TitleDetails : TitleSummary
{
    public required string Rated { get; init; }

    public required string Released { get; init; }

    public required string Runtime { get; init; }

    public required string Genre { get; init; }

    public required string Director { get; init; }

    public required string Writer { get; init; }

    public required string Actors { get; init; }

    public required string Plot { get; init; }

    public required string Language { get; init; }

    public required string Country { get; init; }

    public required string Awards { get; init; }

    public required IEnumerable<TitleRating> Ratings { get; init; } = [];

    public required string Metascore { get; init; }

    public required string ImdbRating { get; init; }

    public required string ImdbVotes { get; init; }

    public required string BoxOffice { get; init; }
}
