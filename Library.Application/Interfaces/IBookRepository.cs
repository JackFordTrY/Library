using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IBookRepository
{
    public int BooksCount { get; }

    IQueryable<Book> GetAllBooks(string order, string direction);

    IEnumerable<Book>? SearchByString(string search);

    IQueryable<Book> GetBookByTitle(string title);

    Task<bool> AddToListAsync(string title, User user);

    Task<bool> DeleteFromListAsync(string title, User user);    
}
