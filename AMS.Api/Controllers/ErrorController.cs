namespace AMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception 
            switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already Exists"), 
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };
        
        return Problem(statusCode:statusCode,title:message);
    }
}

