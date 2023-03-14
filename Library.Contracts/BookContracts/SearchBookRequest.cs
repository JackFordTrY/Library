using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record SearchBookRequest(IEnumerable<SearchQueryBookDto> Books);
