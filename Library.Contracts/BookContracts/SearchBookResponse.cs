using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record SearchBookResponse(IEnumerable<SearchQueryBookDto> Books);
