using Library.Application.Books.DTO;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.BookByTitle;

public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, GetBookByTitleQueryResponse>
{
    private readonly IBookRepository _repository;

    public GetBookByTitleQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetBookByTitleQueryResponse> Handle(GetBookByTitleQuery query, CancellationToken cancellationToken)
    {
        var book = await _repository.GetBookByTitleAsync(query.Title);

        if(book is null) 
        {
            throw new BookNotFoundException();
        }

        var bookDto = new DisplayBookDto(
            book.Title,
            book.Date,
            book.Cover,
            book.Description is null ? string.Empty : book.Description,
            book.Author is null ? string.Empty : book.Author.AuthorName);

        return new GetBookByTitleQueryResponse(bookDto);
    }
}
