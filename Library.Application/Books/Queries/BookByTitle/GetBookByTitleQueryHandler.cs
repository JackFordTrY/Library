using Library.Application.Books.DTO;
using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Books.Queries.BookByTitle;

public class GetBookByTitleQueryHandler : IRequestHandler<GetBookByTitleQuery, GetBookByTitleQueryResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    public GetBookByTitleQueryHandler(IBookRepository bookRepository, IUserRepository userRepository)
    {
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public async Task<GetBookByTitleQueryResponse> Handle(GetBookByTitleQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByLoginAsync(query.Username);

        var book = _bookRepository
            .GetBookByTitle(query.Title)
            .Select(b => new BookPageDto(
                b.Title,
                b.Date,
                b.UsersMarked.Count,
                b.Cover,
                b.Genre,
                b.Description ?? string.Empty,
                b.UaDescription ?? string.Empty,
                b.Author == null ? string.Empty : b.Author.AuthorName,
                b.EPubLink,
                b.MobiLink,
                b.PDFLink,
                b.UsersMarked.Contains(user!)
             ))
            .FirstOrDefault();

        if(book is null) 
        {
            throw new BookNotFoundException();
        }

        return new GetBookByTitleQueryResponse(book);
    }
}
