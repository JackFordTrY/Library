using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public int Date { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public string Cover { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string UaDescription { get; set; } = string.Empty;

    public List<User> UsersMarked { get; set; } = new();

    public BookGenre Genre { get; set; }

    public string? EPubLink { get; set; } = string.Empty;

    public string? MobiLink { get; set; } = string.Empty;

    public string? PDFLink { get; set; } = string.Empty;
}
