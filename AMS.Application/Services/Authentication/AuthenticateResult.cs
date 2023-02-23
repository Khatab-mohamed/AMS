namespace AMS.Application.Services.Authentication
{
    public record AuthenticateResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token
);
}
