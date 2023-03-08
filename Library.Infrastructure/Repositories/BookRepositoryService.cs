using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepositoryService : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepositoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public int BookCount { get => _context.Books.Count(); }

    public IEnumerable<Book> GetAllBooks(int page, string sort)
    {
        var books = _context.Books.Select(b => b).Skip((page - 1) * 24).Take(24);

        switch (sort)
        {
            case "title":
                books = books.OrderBy(b => b.Title);
                break;
            case "novelti_asc":
                books = books.OrderBy(b => b.Date);
                break;
            case "novelti_des":
                books = books.OrderByDescending(b => b.Date);
                break;
            default:
                books = books.OrderBy(b => b.Title);
                break;
        }

        return books.AsEnumerable();
    }

    public async Task<Book?> GetBookByTitleAsync(string title)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title.ToLower() == title);
    }
}
