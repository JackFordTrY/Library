using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.SearchBook;

public record SearchBookResponse(IEnumerable<SearchQueryBookDto> Books);