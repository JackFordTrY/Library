using Library.Application.Books.DTO;

namespace Library.Contracts.BookContracts;

public record GetBookByTitleRequest(BookDto Book);
