using MediatR;

namespace Library.Application.Books.Queries.BookByTitle; 

public record GetBookByTitleQuery(
    string Title) : IRequest<GetBookByTitleResponse>;
