using Library.Domain.Enums;

namespace Library.Application.Books.DTO;

public record BookPageDto(
    string Title,
    int Date,
    int ReadersCount,
    string Cover,
    BookGenre Genre,
    string Description,
    string AutorName);
