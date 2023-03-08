using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record GetAllBookRequest(
    IEnumerable<BookDto> Books,
    int Page,
    string Sort,
    int Count);
