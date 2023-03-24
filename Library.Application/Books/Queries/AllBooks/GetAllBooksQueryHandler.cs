using Library.Application.Books.DTO;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.AllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksQueryResponse>
{
    private readonly IBookRepository _repository;

    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<GetAllBooksQueryResponse> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
    {
        var books = _repository.GetAllBooks(query.Page, query.CountPerPage);

        if (query.YearFrom > 0 && query.YearTo > 0) books = books.Where(b => query.YearFrom <= b.Date && b.Date <= query.YearTo);
        if (query.GenreFilters.Length > 0) books = books.Where(b => query.GenreFilters.Contains(b.Genre));

        var booksDto = books.Select(b => new DisplayBookDto(
            b.Title,
            b.Date,
            b.Cover,
            b.Author is null ? string.Empty : b.Author.AuthorName));

        return Task.FromResult(new GetAllBooksQueryResponse(
            booksDto, 
            query.Page<Math.Ceiling(_repository.BookCount/(double)query.CountPerPage
            )));
    }
}
