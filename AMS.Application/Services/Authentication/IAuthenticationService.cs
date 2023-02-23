namespace AMS.Application.Services.Authentication;
public interface IAuthenticationService
    {
        AuthenticateResult Register(string firstName, string lastName, string email, string password);
        AuthenticateResult Login(string email, string password);
    }
