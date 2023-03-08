using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.AllBooks;

public record GetAllBooksResponse(
    IEnumerable<BookDto> Books,
    int Page,
    string Sort,
    int Count);