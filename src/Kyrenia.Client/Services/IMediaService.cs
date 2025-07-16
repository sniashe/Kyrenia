using Kyrenia.Contracts.DTOs;

namespace Kyrenia.Client.Services;

public interface IMediaService
{
    Task<MediaSearchResultDto> SearchMediaAsync(string title);
    Task<MediaFullDetailsDto> GetMediaDetailsAsync(string id);
}
