using MediatR;

namespace Library.Application.Books.Queries.SearchBook;

public record SearchBookQuery(string SearchString): IRequest<SearchBookQueryResponse>;
