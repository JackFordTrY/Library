using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Users.Commands.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand>
{
    private readonly IUserRepository _repository;
    private readonly IPasswordEncryption _encryption;

    public RegisterCommandHandler(IUserRepository repository, IPasswordEncryption encryption)
    {
        _repository = repository;
        _encryption = encryption;
    }

    public Task Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if(_repository.UserExistsAsync(command.Login, command.Email).Result) 
        {
            throw new UserAlreadyExistsException();
        }

        var user = new User()
        {
            Login = command.Login,
            Email = command.Email,
            Password = _encryption.Encrypt(command.Password)
        };

        _repository.Add(user);

        return Task.CompletedTask;
    }
}
