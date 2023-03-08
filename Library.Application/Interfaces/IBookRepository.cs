using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    public int BookCount { get; }

    IEnumerable<Book> GetAllBooks(int page, string sort);

    Task<Book?> GetBookByTitleAsync(string title);
}
