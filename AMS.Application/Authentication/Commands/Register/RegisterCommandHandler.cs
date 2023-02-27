using AMS.Domain.UserAggregate;

namespace AMS.Application.Authentication.Commands.Register;
public class RegisterCommandHandler: 
    IRequestHandler<RegisterCommand,ErrorOr<AuthenticateResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jWtTokenGenerator)
    {
        _userRepository = userRepository;
        _jWtTokenGenerator = jWtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticateResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userByEmail = _userRepository.GetUserByEmail(command.Email,command.Password);
        if (userByEmail is not null)
        {
            return Errors.User.DuplicateEmail;

        }

        var user = new User
        {
            FullName = command.FirstName + " " + command.LastName,
            Email = command.Email,
            Password = command.Password,

            /*for now The Creator User*/
            UserTypeId = Guid.NewGuid(),

        };

        await _userRepository.AddUser(user);

            
        var token = _jWtTokenGenerator.GenerateToken(user);
        return new AuthenticateResult(
            user,
            token);
    }
}