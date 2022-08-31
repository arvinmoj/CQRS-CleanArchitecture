using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Users;
public class User : Base.Entity
{
    public User() : base()
    {
    }

    [Required]
    [MaxLength(length: 100)]
    public string Username { get; set; }

    [Required]
    [MaxLength(length: 100)]
    [DataType(dataType: DataType.Password)]
    public string Password { get; set; }

    [Required]
    [MaxLength(length: 100)]
    [DataType(dataType: DataType.EmailAddress)]
    public string Email { get; set; }
}
