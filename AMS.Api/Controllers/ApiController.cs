using AMS.Api.Common.Http;

namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController :ControllerBase
{
   
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors]=errors;
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,

        };

        return Problem(statusCode:statusCode,title:firstError.Description);

    }
}