namespace Kyrenia.Contracts.DTOs;

public class MediaSearchResultDto
{
    public IEnumerable<MediaDetailsDto> Items { get; init; }

    public MediaSearchResultDto(IEnumerable<MediaDetailsDto>? items = null)
    {
        Items = items ?? [];
    }
}
