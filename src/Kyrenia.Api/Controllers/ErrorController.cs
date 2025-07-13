using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Kyrenia.Api.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    private readonly IHostEnvironment _environment;

    public ErrorController(IHostEnvironment environment)
    {
        _environment = environment;
    }

    [Route("/error")]
    public IActionResult HandleError()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem(
            title: "An unexpected error occured.",
            detail: _environment.IsDevelopment() ? exception?.Message : null,
            statusCode: StatusCodes.Status500InternalServerError
        );
    }
}
