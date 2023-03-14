using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record GetAllBookRequest(
    IEnumerable<DisplayBookDto> Books,
    int Page,
    string Sort,
    int Count);
