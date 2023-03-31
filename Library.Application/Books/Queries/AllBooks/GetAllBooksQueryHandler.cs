using Library.Application.Books.DTO;
using Library.Application.Interfaces;
using Newtonsoft.Json;
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
        var books = _repository.GetAllBooks(
            query.Order,
            query.Direction
        );

        if (query.YearFrom > 0) books = books.Where(b => query.YearFrom <= b.Date);

        if (query.YearTo > 0) books = books.Where(b => b.Date <= query.YearTo);
        
        if (query.GenreFilters.Length > 0) books = books.Where(b => 
            JsonConvert.DeserializeObject<int[]>(query.GenreFilters)!.Contains((int)b.Genre
        ));

        books = books
            .Skip((query.Page - 1) * query.CountPerPage)
            .Take(query.CountPerPage);

        var booksDto = books.Select(b => new DisplayBookDto(
            b.Title,
            b.Date,
            b.Cover,
            b.Author == null ? string.Empty : b.Author.AuthorName));

        return Task.FromResult(new GetAllBooksQueryResponse(
            booksDto, 
            query.Page<Math.Ceiling(_repository.BookCount/(double)query.CountPerPage
        )));
    }
}
