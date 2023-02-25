using AMS.Application.Authentication.Common;

namespace AMS.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticateResult>>;