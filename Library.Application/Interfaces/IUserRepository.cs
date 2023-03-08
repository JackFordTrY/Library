using Library.Domain.Entities;

namespace Library.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByLogin(string username);

    Task<bool> UserExists(string username, string email);

    void Add(User user);
}
