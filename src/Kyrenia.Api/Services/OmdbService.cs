using Kyrenia.Api.Configuration;
using Kyrenia.Api.DTOs;
using Microsoft.Extensions.Options;

namespace Kyrenia.Api.Services;

public class OmdbService : IOmdbService
{
    private readonly HttpClient _httpClient;
    private readonly OmdbOptions _options;

    public OmdbService(HttpClient httpClient, IOptions<OmdbOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<MovieFullDetailsDto> GetMovieDetailsAsync(string imdbId)
    {
        var response = await _httpClient.GetAsync($"{_options.BaseUrl}?apikey={_options.ApiKey}&type=movie&plot=full&i={Uri.EscapeDataString(imdbId)}");

        // 0xTD Process response

        throw new NotImplementedException();
    }

    public async Task<MovieSearchResultDto> SearchMoviesAsync(string title)
    {
        var response = await _httpClient.GetAsync($"{_options.BaseUrl}?apikey={_options.ApiKey}&type=movie&s={Uri.EscapeDataString(title)}");

        // 0xTD Process response

        throw new NotImplementedException();
    }
}
