namespace Kyrenia.Api.DTOs;

public class MovieSearchResultDto
{
    public List<MovieDetailsDto> Movies { get; init; }

    public MovieSearchResultDto(List<MovieDetailsDto>? movies = null)
    {
        Movies = movies ?? [];
    }
}
