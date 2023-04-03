using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record GetAllBookResponse(
    IEnumerable<BookListDto> Books,
    bool HasNextPage);
