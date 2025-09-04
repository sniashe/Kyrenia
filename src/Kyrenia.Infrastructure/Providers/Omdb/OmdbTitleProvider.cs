using Kyrenia.Application.Models;
using Kyrenia.Application.Providers;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Kyrenia.Infrastructure.Providers.Omdb;

internal class OmdbTitleProvider : ITitleProvider
{
    private readonly HttpClient _httpClient;
    private readonly TitleProviderOptions _titleProviderOptions;

    public OmdbTitleProvider(HttpClient httpClient, IOptions<TitleProviderOptions> titleProviderOptions)
    {
        _httpClient = httpClient;
        _titleProviderOptions = titleProviderOptions.Value;
    }

    public async Task<IEnumerable<TitleSummary>> GetAllAsync(GetTitlesOptions options)
    {
        var query = $"{_titleProviderOptions.BaseUrl}?apikey={_titleProviderOptions.ApiKey}&type=movie&s={options.Name}";

        var httpResponse = await _httpClient.GetAsync(query);

        if (httpResponse.IsSuccessStatusCode is false)
        {
            throw new Exception($"TitleProvider failed with status {httpResponse.StatusCode}");
        }

        var omdbResponse = await httpResponse.Content.ReadFromJsonAsync<OmdbTitlesResponse>();

        if (omdbResponse?.Search is null)
        {
            return [];
        }

        return omdbResponse.Search.Select(OmdbMapping.MapToSummary);
    }

    public async Task<TitleDetails> GetByExternalIdAsync(string id)
    {
        var query = $"{_titleProviderOptions.BaseUrl}?apikey={_titleProviderOptions.ApiKey}&type=movie&i={id}";

        var httpResponse = await _httpClient.GetAsync(query);

        if (httpResponse.IsSuccessStatusCode is false)
        {
            throw new Exception($"TitleProvider failed with status {httpResponse.StatusCode}");
        }

        var response = await httpResponse.Content.ReadFromJsonAsync<OmdbTitleResponse>();

        return response!.MapToDetails();
    }
}
