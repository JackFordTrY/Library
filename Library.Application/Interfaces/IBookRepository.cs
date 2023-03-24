using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    public int BookCount { get; }

    IEnumerable<Book> GetAllBooks(int page, int count);

    public IEnumerable<Book>? SearchByString(string search);

    Task<Book?> GetBookByTitleAsync(string title);
}
