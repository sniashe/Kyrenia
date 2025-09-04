using Kyrenia.Application.Models;
using Kyrenia.Domain.Models.Enums;

namespace Kyrenia.Infrastructure.Providers.Omdb;

internal static class OmdbMapping
{
    public static TitleSummary MapToSummary(this OmdbTitleSummary summary)
    {
        return new TitleSummary
        {
            Name = summary.Title,
            ExternalId = summary.ImdbID,
            Type = Enum.TryParse(summary.Type, true, out TitleType type) ? type : null,
            Poster = summary.Poster,
            Year = summary.Year
        };
    }

    public static TitleDetails MapToDetails(this OmdbTitleResponse details)
    {
        return new TitleDetails
        {
            Name = details.Title,
            ExternalId = details.ImdbID,
            Type = Enum.TryParse(details.Type, true, out TitleType type) ? type : null,
            Poster = details.Poster,
            Year = details.Year,
            Rated = details.Rated,
            Released = details.Released,
            Runtime = details.Runtime,
            Genre = details.Genre,
            Director = details.Director,
            Writer = details.Writer,
            Actors = details.Actors,
            Plot = details.Plot,
            Language = details.Language,
            Country = details.Country,
            Awards = details.Awards,
            Ratings = details.Ratings.Select(r =>
                new TitleRating(r.Source, r.Value)
            ),
            Metascore = details.Metascore,
            ImdbRating = details.ImdbRating,
            ImdbVotes = details.ImdbVotes,
            BoxOffice = details.BoxOffice
        };
    }
}
