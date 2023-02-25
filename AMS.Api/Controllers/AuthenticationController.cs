using AMS.Application.Authentication.Queries.Login;
using AMS.Domain.Common.Errors;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

            var command = _mapper.Map<RegisterCommand>(request);

            var  authResult =  await _mediator.Send(command);

            return authResult.MatchFirst(
                authenticateResult => Ok(_mapper.Map<AuthenticateResponse>(authenticateResult)),
                firstError=> Problem(statusCode:StatusCodes.Status409Conflict,title:firstError.Description));
        }

        

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description);
            }


            return authResult.Match(
                authenticateResult => Ok(_mapper.Map<AuthenticateResponse>(authenticateResult)),
                errors => Problem(errors));
        }
    }
}
