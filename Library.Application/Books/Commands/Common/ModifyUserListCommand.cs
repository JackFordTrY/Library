using MediatR;

namespace Library.Application.Books.Commands.Common;

public record ModifyUserListCommand(
    string BookTitle,
    string Username) : IRequest<bool>;
