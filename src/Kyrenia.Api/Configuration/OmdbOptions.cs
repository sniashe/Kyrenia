namespace Kyrenia.Api.Configuration;

public class OmdbOptions
{
    public const string SectionName = "OmdbApi";
    public string ApiKey { get; set; } = string.Empty;
    public string BaseUrl { get; set; } = string.Empty;
}
