using AMS.Application.Authentication.Common;

namespace AMS.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticateResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, 
        IJwtTokenGenerator jWtTokenGenerator)
    {
        _userRepository = userRepository;
        _jWtTokenGenerator = jWtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticateResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(query.Email, query.Password) is not { } user)
        {
            throw new Exception("User With Given email doesn't exist.");
        }

        if (user.Password != query.Password)
        {
            throw new Exception("Invalid password.");
        }

        var token = _jWtTokenGenerator.GenerateToken(user);
        return new AuthenticateResult(
            user,
            Token: token);
    }
}