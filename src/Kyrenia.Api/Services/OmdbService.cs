using Kyrenia.Api.Configuration;
using Kyrenia.Api.DTOs;
using Microsoft.Extensions.Options;
using System.Text.Json;

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

        if (!response.IsSuccessStatusCode)
        {
            return new MovieFullDetailsDto();
        }

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<MovieFullDetailsDto>(json) ?? new MovieFullDetailsDto();
    }

    public async Task<MovieSearchResultDto> SearchMoviesAsync(string title)
    {
        var response = await _httpClient.GetAsync($"{_options.BaseUrl}?apikey={_options.ApiKey}&type=movie&s={Uri.EscapeDataString(title)}");

        if (!response.IsSuccessStatusCode)
        {
            // 0xTD Log the error
            return new MovieSearchResultDto();
        }

        var json = await response.Content.ReadAsStringAsync();
        var root = JsonSerializer.Deserialize<JsonElement>(json);

        if (root.TryGetProperty("Search", out var searchResults))
        {
            var movies = JsonSerializer.Deserialize<List<MovieDetailsDto>>(searchResults);

            return new MovieSearchResultDto(movies);
        }

        return new MovieSearchResultDto();
    }
}
