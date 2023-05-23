using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Library.Infrastructure.Repositories;

public class BookRepositoryService : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepositoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public int BooksCount { get => _context.Books.Count(); }

    public IQueryable<Book> GetAllBooks(string order, string direction)
    {
        var books = _context.Books
            .Include(b => b.Author)
            .AsQueryable();
            
        switch (direction)
        {
            case "Ascending":
                books = books.OrderBy(order);
                break;
            case "Descending":
                books = books.OrderBy(order + " desc");
                break;
        }

        return books;
    }

    public IEnumerable<Book>? SearchByString(string search)
    {
        if (string.IsNullOrEmpty(search)) return null;

        return _context.Books
            .Where(b => b.Title.ToLower().Contains(search.ToLower()))
            .Include(b => b.Author)
            .AsEnumerable();
    } 

    public IQueryable<Book> GetBookByTitle(string title)
    {
        return _context.Books
            .Include(b => b.UsersMarked)
            .Include(b => b.Author)
            .Where(b => b.Title.ToLower() == title);
    }

    public async Task<bool> AddToListAsync(string title, User user)
    {
        var book = await _context.Books.Include(b=>b.UsersMarked).FirstAsync(b => b.Title == title);

        if (!book.UsersMarked.Contains(user))
        {
            book.UsersMarked.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteFromListAsync(string title, User user)
    {
        var book = await _context.Books.Include(b => b.UsersMarked).FirstAsync(b => b.Title == title);

        if (book.UsersMarked.Contains(user))
        {
            book.UsersMarked.Remove(user);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}
