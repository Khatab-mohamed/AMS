

using AMS.Application.Common.Interfaces.Persistence;
using AMS.Domain.Entities.Authentication;

namespace AMS.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static  readonly List<User> Users = new();

    
    public User? GetUserByEmail(string email, string password)
    {
        return Users.FirstOrDefault(u=>u.Email == email && u.Password == password);
    }

    public Task AddUser(User user)
    { 
        Users.Add(user);
        return Task.CompletedTask;
    }
}
