using Library.Application.Books.DTO;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.SearchBook;

public class SearchBookQueryHandler : IRequestHandler<SearchBookQuery, SearchBookResponse>
{
    private readonly IBookRepository _repository;

    public SearchBookQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public Task<SearchBookResponse> Handle(SearchBookQuery query, CancellationToken cancellationToken)
    {
        var books = _repository.SearchByString(query.SearchString);

        if (books == null) return Task.FromResult(new SearchBookResponse(null!));

        var booksDto = books.Select(b => new SearchQueryBookDto(
            b.Title, 
            b.Author is null ? string.Empty : b.Author.AuthorName
            ));

        return Task.FromResult(new SearchBookResponse(booksDto));
    }
}
