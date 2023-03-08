using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByLoginAsync(string username);

    Task<bool> UserExistsAsync(string username, string email);

    void Add(User user);
}
