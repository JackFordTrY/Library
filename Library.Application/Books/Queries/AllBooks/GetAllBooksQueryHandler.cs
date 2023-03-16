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
        var books = _repository.GetAllBooks(query.Page, query.Sort);

        var booksDto = books.Select(b => new DisplayBookDto(
            b.Title,
            b.Date,
            b.Cover,
            b.Description is null ? string.Empty : b.Description,
            b.Author is null ? string.Empty : b.Author.AuthorName));

        return Task.FromResult(new GetAllBooksQueryResponse(booksDto, query.Page, query.Sort, _repository.BookCount));
    }
}
