using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }

    public string AuthorName { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }

    public DateOnly DeathDate { get; set; }

    public List<Book> BooksWritten { get; set; } = new();
}

