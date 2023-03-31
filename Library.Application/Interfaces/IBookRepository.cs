using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    public int BookCount { get; }

    IQueryable<Book> GetAllBooks(string order, string direction);

    public IEnumerable<Book>? SearchByString(string search);

    Task<Book?> GetBookByTitleAsync(string title);
}
