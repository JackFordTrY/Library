using Library.Application.Books.Commands.AddToList;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Commands.DeleteFromList;

public class DeleteFromListCommandHandler : IRequestHandler<DeleteFromListCommand, bool>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    public DeleteFromListCommandHandler(IBookRepository bookRepository, IUserRepository userRepository)
    {
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(DeleteFromListCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByLoginAsync(request.Username);

        return await _bookRepository.DeleteFromListAsync(request.BookTitle, user!);
    }
}
