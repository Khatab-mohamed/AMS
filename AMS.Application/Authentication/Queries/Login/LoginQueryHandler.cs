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
        var useByEmail = _userRepository.GetUserByEmail(query.Email, query.Password);
        if (useByEmail is  { })
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (useByEmail?.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jWtTokenGenerator.GenerateToken(useByEmail);
        return new AuthenticateResult(
            useByEmail,
            Token: token);
    }
}