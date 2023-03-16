using MediatR;

namespace Library.Application.Books.Queries.AllBooks;
public record GetAllBooksQuery(
    int Page,
    string Sort) : IRequest<GetAllBooksQueryResponse>;
