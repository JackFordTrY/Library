using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    public int BookCount { get; }

    IEnumerable<Book> GetAllBooks(int page, string sort);

    public IEnumerable<Book>? SearchByString(string search);

    Task<Book?> GetBookByTitleAsync(string title);
}
