using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Commands.AddToList;

internal class AddToListCommandHandler : IRequestHandler<AddToListCommand, bool>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    public AddToListCommandHandler(IBookRepository bookRepository, IUserRepository userRepository)
    {
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> Handle(AddToListCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByLoginAsync(request.Username);

        return await _bookRepository.AddToListAsync(request.BookTitle, user!);
    }
}
