using Library.Application.Books.Commands.Common;

namespace Library.Application.Books.Commands.DeleteFromList;

public record DeleteFromListCommand(string BookTitle, string Username) : ModifyUserListCommand(BookTitle, Username);
