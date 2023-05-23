using MediatR;

namespace Library.Application.Books.Queries.BookByTitle; 

public record GetBookByTitleQuery(
    string Title,
    string Username) : IRequest<GetBookByTitleQueryResponse>;
