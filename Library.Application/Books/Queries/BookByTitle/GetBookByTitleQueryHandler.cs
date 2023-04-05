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

    public Task<GetBookByTitleQueryResponse> Handle(GetBookByTitleQuery query, CancellationToken cancellationToken)
    {
        var book = _repository
            .GetBookByTitle(query.Title)
            .Select(b => new BookPageDto(
                b.Title,
                b.Date,
                b.UsersMarked.Count,
                b.Cover,
                b.Genre,
                b.Description ?? string.Empty,
                b.Author == null ? string.Empty : b.Author.AuthorName,
                b.EPubLink,
                b.MobiLink,
                b.PDFLink
             ))
            .FirstOrDefault();

        if(book is null) 
        {
            throw new BookNotFoundException();
        }

        return Task.FromResult(new GetBookByTitleQueryResponse(book));
    }
}
