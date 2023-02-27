using AMS.Domain.UserAggregate;

namespace AMS.Application.Authentication.Common;
public record AuthenticateResult(
    User User,
    string Token
);
