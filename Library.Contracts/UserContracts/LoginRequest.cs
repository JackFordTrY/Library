using System.ComponentModel.DataAnnotations;

namespace Library.Contracts.UserContracts;

public class LoginRequest
{
    [Required]
    public string Login { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

}
