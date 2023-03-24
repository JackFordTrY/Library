using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Library.Infrastructure.Repositories;

public class BookRepositoryService : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepositoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public int BookCount { get => _context.Books.Count(); }

    public IEnumerable<Book> GetAllBooks(int page, int count)
    {
        var books = _context.Books.Select(b => b).Include(b => b.Author).Skip((page-1) * count).Take(count);

        return books.AsEnumerable();
    }

    public IEnumerable<Book>? SearchByString(string search)
    {
        if (string.IsNullOrEmpty(search)) return null;

        return _context.Books.Select(b => b).Where(b=>b.Title.ToLower().Contains(search.ToLower())).Include(b => b.Author).AsEnumerable();
    } 

    public async Task<Book?> GetBookByTitleAsync(string title)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Title.ToLower() == title);
    }

    
}
