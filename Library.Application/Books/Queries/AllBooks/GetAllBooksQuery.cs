using Library.Domain.Enums;
using MediatR;

namespace Library.Application.Books.Queries.AllBooks;
public record GetAllBooksQuery : IRequest<GetAllBooksQueryResponse>
{
    public int Page { get; set; } 
    public int CountPerPage { get; set; } = 30;
    public int YearFrom { get; set; }
    public int YearTo { get; set; }
    public string Order { get; set; } = "Title";
    public string Direction { get; set; } = "Ascending";
    public string GenreFilters { get; set; } = string.Empty;
}
