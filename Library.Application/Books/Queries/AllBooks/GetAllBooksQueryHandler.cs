using Library.Application.Books.DTO;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.AllBooks;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksResponse>
{
    private readonly IBookRepository _repository;

    public GetAllBooksQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<GetAllBooksResponse> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
    {
        var books = _repository.GetAllBooks(query.Page, query.Sort);

        var booksDto = books.Select(b => new BookDto(
            b.Title,
            b.Date,
            b.Cover,
            b.Description is null ? string.Empty : b.Description,
            b.Author is null ? string.Empty : b.Author.AuthorName));

        return Task.FromResult(new GetAllBooksResponse(booksDto, query.Page, query.Sort, _repository.BookCount));
    }
}
