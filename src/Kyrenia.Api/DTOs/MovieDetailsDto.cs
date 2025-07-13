using System.Text.Json.Serialization;

namespace Kyrenia.Api.DTOs;

public class MovieDetailsDto
{
    public string Title { get; set; } = string.Empty;

    public string Year { get; set; } = string.Empty;

    [JsonPropertyName("imdbID")]
    public string ImdbID { get; set; } = string.Empty;

    public string Poster { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
}
