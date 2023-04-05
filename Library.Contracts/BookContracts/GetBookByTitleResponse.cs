using Library.Application.Books.DTO;
using Library.Domain.Enums;

namespace Library.Contracts.BookContracts;

public record GetBookByTitleResponse(
    string Title,
    int Date,
    int ReadersCount,
    string Cover,
    BookGenre Genre,
    string Description,
    string AutorName,
    string? EPubLink,
    string? MobiLink,
    string? PdfLink);
