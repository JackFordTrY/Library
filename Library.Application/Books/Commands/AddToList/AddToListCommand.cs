using Library.Application.Books.Commands.Common;
using MediatR;

namespace Library.Application.Books.Commands.AddToList;

public record AddToListCommand(string BookTitle,string Username) : ModifyUserListCommand(BookTitle,Username);
