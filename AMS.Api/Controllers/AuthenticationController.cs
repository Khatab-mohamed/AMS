using AMS.Application.Authentication.Common;
using AMS.Application.Authentication.Queries.Login;
using AMS.Domain.Common.Errors;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var command = new RegisterCommand(
                request.FirstName,
                 request.LastName,
                 request.Email,
                  request.Password);

            var  authResult =  await _mediator.Send(command);

            return authResult.MatchFirst(
                authResult=> Ok(MapAuthResult(authResult)),
                firstError=> Problem(statusCode:StatusCodes.Status409Conflict,title:firstError.Description));
        }

        

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequset request)
        {
            var query = new LoginQuery(
                request.Email,
                request.Password);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }


            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors));
        }


        private static AuthenticateResponse MapAuthResult(AuthenticateResult authenticateResult) =>
            new(
                authenticateResult.User.Id,
                authenticateResult.User.FullName,
                authenticateResult.User.FullName,
                authenticateResult.User.Email,
                authenticateResult.Token);

    }
}
