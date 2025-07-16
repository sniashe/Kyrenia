using Kyrenia.Client.Configuration;
using Kyrenia.Contracts.DTOs;
using Microsoft.Extensions.Options;

namespace Kyrenia.Client.Services;

public class MediaService : IMediaService
{
    private readonly HttpClient _httpClient;
    private readonly MediaServiceOptions _options;

    public MediaService(HttpClient httpClient, IOptions<MediaServiceOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<MediaFullDetailsDto> GetMediaDetailsAsync(string externalId)
    {
        var response = await _httpClient.GetFromJsonAsync<MediaFullDetailsDto>($"{_options.BaseUrl}api/movie/{Uri.EscapeDataString(externalId)}");

        return response;
    }

    public async Task<MediaSearchResultDto> SearchMediaAsync(string title)
    {
        var response = await _httpClient.GetFromJsonAsync<MediaSearchResultDto>($"{_options.BaseUrl}api/movie/search?title={Uri.EscapeDataString(title)}");

        return response;
    }
}
