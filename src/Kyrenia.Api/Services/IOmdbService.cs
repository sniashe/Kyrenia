using Kyrenia.Api.DTOs;

namespace Kyrenia.Api.Services;

public interface IOmdbService
{
    Task<MovieSearchResultDto> SearchMoviesAsync(string title);
    Task<MovieFullDetailsDto> GetMovieDetailsAsync(string imdbId);
}
