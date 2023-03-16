using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.AllBooks;

public record GetAllBooksQueryResponse(
    IEnumerable<DisplayBookDto> Books,
    int Page,
    string Sort,
    int Count);