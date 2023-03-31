using Library.Application.Books.DTO;

namespace Library.Application.Books.Queries.SearchBook;

public record SearchBookQueryResponse(IEnumerable<SearchQueryBookDto> Books);