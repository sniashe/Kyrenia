namespace Kyrenia.Application.Providers;

public class TitleProviderOptions
{
    public const string SectionName = "TitleProvider";

    public required string BaseUrl { get; init; }

    public required string ApiKey { get; init; }
}
