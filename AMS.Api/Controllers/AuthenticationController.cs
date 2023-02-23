using AMS.Application.Services.Authentication;
using AMS.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) => _authenticationService = authenticationService;

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(
                request.FirstName,
                 request.LastName,
                 request.Email,
                  request.Password);

            var response = new AuthenticateResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequset request)
        {

            var authResult = _authenticationService.Login(
                 request.Email,
                  request.Password);

            var response = new AuthenticateResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}
