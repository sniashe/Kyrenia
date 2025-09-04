using Kyrenia.Domain.Models.Enums;

namespace Kyrenia.Application.Models;

public class TitleSummary
{
    public required string Name { get; init; }

    public required string ExternalId { get; init; }

    public required TitleType? Type { get; init; }

    public required string Year { get; init; }

    public required string Poster {  get; init; }
}
