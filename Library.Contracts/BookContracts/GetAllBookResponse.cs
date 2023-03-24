using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record GetAllBookResponse(
    IEnumerable<DisplayBookDto> Books,
    bool HasNextPage);
