namespace Kyrenia.Contracts.DTOs;

public class MediaFullDetailsDto : MediaDetailsDto
{
    public string Rated { get; set; } = string.Empty;

    public string Released { get; set; } = string.Empty;

    public string Runtime { get; set; } = string.Empty;

    public string Genre { get; set; } = string.Empty;

    public string Director { get; set; } = string.Empty;

    public string Writer { get; set; } = string.Empty;

    public string Actors { get; set; } = string.Empty;

    public string Plot { get; set; } = string.Empty;

    public string Language { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string Awards { get; set; } = string.Empty;

    public IEnumerable<MediaRatingDto> Ratings { get; set; } = [];

    public string Metascore { get; set; } = string.Empty;

    public string ImdbRating { get; set; } = string.Empty;

    public string ImdbVotes { get; set; } = string.Empty;

    public string BoxOffice { get; set; } = string.Empty;
}
