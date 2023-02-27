using AMS.Domain.UserAggregate.Authentication;

namespace AMS.Domain.UserAggregate;
[Table("User")]
public class User : Base
{

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Email { get; set; }

    public int IdNumber { get; set; }
    public string? Phone { get; set; }

    [Required]
    public string Password { get; set; }



    public Guid UserTypeId { get; set; }
    public UserType UserType { get; set; }
}