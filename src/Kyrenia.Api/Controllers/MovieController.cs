using Kyrenia.Api.Services;
using Kyrenia.Application.Services;
using Kyrenia.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Kyrenia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IOmdbService _omdbService;
    private readonly ITitleService _titleService;

    public MovieController(IOmdbService omdbService, ITitleService titleService)
    {
        _omdbService = omdbService;
        _titleService = titleService;
    }

    [HttpGet("{imdbId}")]
    public async Task<IActionResult> GetMovieDetails(string imdbId)
    {
        if (string.IsNullOrWhiteSpace(imdbId))
        {
            return BadRequest("IMDb ID must be provided.");
        }

        var omdbResult = await _omdbService.GetMovieDetailsAsync(imdbId);
        var imdbResult = await _titleService.GetByExternalIdAsync(imdbId);

        // 0xTD Introduce dedicated mapper class
        var result = new MediaFullDetailsDto
        {
            Title = imdbResult.Name,
            Year = imdbResult.Year,
            ExternalId = imdbResult.ExternalId,
            Poster = imdbResult.Poster,
            Type = imdbResult.Type.ToString() ?? string.Empty,
            Rated = imdbResult.Rated,
            Released = imdbResult.Released,
            Runtime = imdbResult.Runtime,
            Genre = imdbResult.Genre,
            Director = imdbResult.Director,
            Writer = imdbResult.Writer,
            Actors = imdbResult.Actors,
            Plot = imdbResult.Plot,
            Language = imdbResult.Language,
            Country = imdbResult.Country,
            Awards = imdbResult.Awards,
            Ratings = imdbResult.Ratings.Select(r =>
                new MediaRatingDto
                {
                    Source = r.Source,
                    Value = r.Value,
                }
            ),
            Metascore = imdbResult.Metascore,
            ImdbRating = imdbResult.ImdbRating,
            ImdbVotes = imdbResult.ImdbVotes,
            BoxOffice = imdbResult.BoxOffice
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
        var imdbResult = await _titleService.GetAllAsync(title);

        // 0xTD Introduce dedicated mapper class
        var result = new MediaSearchResultDto(
            imdbResult.Select(x =>
                new MediaDetailsDto
                {
                    Title = x.Name,
                    Year = x.Year,
                    ExternalId = x.ExternalId,
                    Poster = x.Poster,
                    Type = x.Type.ToString() ?? string.Empty
                }
            )
        );

        return Ok(result);
    }
}
