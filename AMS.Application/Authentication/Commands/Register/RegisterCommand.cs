using AMS.Application.Authentication.Common;

namespace AMS.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password ) : IRequest<ErrorOr<AuthenticateResult>>;
