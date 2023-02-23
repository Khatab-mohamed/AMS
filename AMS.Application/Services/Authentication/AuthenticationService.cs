using AMS.Application.Common.Interfaces.Authentication;

namespace AMS.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJWTTokenGenerator _jWTTokenGenerator;

    public AuthenticationService(IJWTTokenGenerator jWTTokenGenerator)
    {
        _jWTTokenGenerator = jWTTokenGenerator;
    }

    public AuthenticateResult Register(string firstName, string lastName, string email, string password)
    {

        //  Check if the user already exists
        var userId = Guid.NewGuid();
        var token = _jWTTokenGenerator.GenerateToken(userId, firstName, lastName);
        return new AuthenticateResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }


    public AuthenticateResult Login(string email, string password)
    {
        return new AuthenticateResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }

  
}
