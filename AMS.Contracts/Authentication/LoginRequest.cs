namespace AMS.Contracts.Authentication;
public record LoginRequset(
    string FirstName,
    string LastName,
    string Email,
    string Password
);