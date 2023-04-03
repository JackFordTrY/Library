using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.AllBooks;

public record GetAllBooksQueryResponse(
    IEnumerable<BookListDto> Books,
    bool HasNextPage);