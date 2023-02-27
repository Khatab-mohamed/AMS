using AMS.Domain.UserAggregate;

namespace AMS.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
    User? GetUserByEmail(string email, string password);

    Task AddUser(User user);
}

