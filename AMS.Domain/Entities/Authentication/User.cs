using AMS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AMS.Domain.Entities.Authentication;
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