namespace Library.Application.Books.DTO;

public record DisplayBookDto(string Title, int Date, string Cover, string AutorName);

public record SearchQueryBookDto(string Title, string AuthorName);
