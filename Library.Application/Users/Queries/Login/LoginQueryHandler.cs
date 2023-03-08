using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;
using System.Security.Claims;

namespace Library.Application.Users.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
{
    private readonly IUserRepository _repository;
    private readonly IPasswordEncryption _encryption;

    public LoginQueryHandler(IUserRepository repository, IPasswordEncryption encryption)
    { 
        _repository = repository;
        _encryption = encryption;
    }

    public async Task<LoginQueryResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetUserByLogin(query.Login) is not User user)
        {
            throw new UserNotFoundException();
        }

        if (user.Password != _encryption.Encrypt(query.Password))
        {
            throw new UserNotFoundException();
        }

        var principal = new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login)
                }, "Cookie")
            );

        return new LoginQueryResponse() { Principal = principal };
    }
}
