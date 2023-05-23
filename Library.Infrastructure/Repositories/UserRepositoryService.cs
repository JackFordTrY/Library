using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class UserRepositoryService : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepositoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async void Add(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByLoginAsync(string username)
    {
        return await _context.Users.Include(user => user.BooksMarked).FirstOrDefaultAsync(u => u.Login == username);
    }

    public async Task<bool> UserExistsAsync(string username, string email)
    {
        return await _context.Users.AnyAsync(u => u.Login == username || u.Email == email);
    }
}
