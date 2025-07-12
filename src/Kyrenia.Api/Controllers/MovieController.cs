using Kyrenia.Api.Services;
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

    [HttpGet("search")]
    public async Task<IActionResult> SearchMovies([FromQuery] string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return BadRequest("Title must be provided.");
        }

        var result = await _omdbService.SearchMoviesAsync(title);

        // 0xTD Save search query in repository

        return Ok(result);
    }

    [HttpGet("{imdbId}")]
    public async Task<IActionResult> GetMovieDetails(string imdbId)
    {
        if (string.IsNullOrWhiteSpace(imdbId))
        {
            return BadRequest("IMDb ID must be provided.");
        }

        var details = await _omdbService.GetMovieDetailsAsync(imdbId);

        return Ok(details);
    }
}
