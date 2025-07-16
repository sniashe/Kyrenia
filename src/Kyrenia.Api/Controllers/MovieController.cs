using Kyrenia.Api.Services;
using Kyrenia.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Kyrenia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IOmdbService _omdbService;

    public MovieController(IOmdbService omdbService)
    {
        _omdbService = omdbService;
    }

    [HttpGet("{imdbId}")]
    public async Task<IActionResult> GetMovieDetails(string imdbId)
    {
        if (string.IsNullOrWhiteSpace(imdbId))
        {
            return BadRequest("IMDb ID must be provided.");
        }

        var omdbResult = await _omdbService.GetMovieDetailsAsync(imdbId);

        // 0xTD Introduce dedicated mapper class
        var result = new MediaFullDetailsDto
        {
            Title = omdbResult.Title,
            Year = omdbResult.Year,
            ExternalId = omdbResult.ImdbID,
            Poster = omdbResult.Poster,
            Type = omdbResult.Type,
            Rated = omdbResult.Rated,
            Released = omdbResult.Released,
            Runtime = omdbResult.Runtime,
            Genre = omdbResult.Genre,
            Director = omdbResult.Director,
            Writer = omdbResult.Writer,
            Actors = omdbResult.Actors,
            Plot = omdbResult.Plot,
            Language = omdbResult.Language,
            Country = omdbResult.Country,
            Awards = omdbResult.Awards,
            Ratings = omdbResult.Ratings.Select(r =>
                new MediaRatingDto
                {
                    Source = r.Source,
                    Value = r.Value,
                }
            ),
            Metascore = omdbResult.Metascore,
            ImdbRating = omdbResult.ImdbRating,
            ImdbVotes = omdbResult.ImdbVotes,
            BoxOffice = omdbResult.BoxOffice
        };

        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies([FromQuery] string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Title must be provided.");
        }

        var omdbResult = await _omdbService.SearchMoviesAsync(title);

        // 0xTD Introduce dedicated mapper class
        var result = new MediaSearchResultDto(
            omdbResult.Movies.Select(m =>
                new MediaDetailsDto
                {
                    Title = m.Title,
                    Year = m.Year,
                    ExternalId = m.ImdbID,
                    Poster = m.Poster,
                    Type = m.Type
                }
            ).ToList()
        );

        return Ok(result);
    }
}
