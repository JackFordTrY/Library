using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Login { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public List<Book> BooksMarked { get; set; } = new();
}
