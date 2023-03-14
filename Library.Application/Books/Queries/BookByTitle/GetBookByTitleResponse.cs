using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.BookByTitle;

public record GetBookByTitleResponse(
    DisplayBookDto Book);
