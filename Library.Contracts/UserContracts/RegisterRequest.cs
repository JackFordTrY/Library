using System.ComponentModel.DataAnnotations;

namespace Library.Contracts.UserContracts;

public record RegisterRequest
{
    [Required(ErrorMessage = "This field can not be empty.")]
    [MaxLength(10, ErrorMessage = "Login maximum length is 10 symbols.")]
    public string Login { get; set; } = string.Empty;

    [Required(ErrorMessage = "This field can not be empty.")]
    [EmailAddress(ErrorMessage = "This is not a valid e-mail.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "This field can not be empty.")]
    public string Password { get; set; } = string.Empty;
}
