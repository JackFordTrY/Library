using Library.Domain.Enums;

namespace Library.Application.Books.DTO;

public record BookPageDto(
    string Title,
    int Date,
    int ReadersCount,
    string Cover,
    BookGenre Genre,
    string Description,
    string UaDescription,
    string AutorName,
    string? EPubLink,
    string? MobiLink,
    string? PdfLink,
    bool IsInList);
