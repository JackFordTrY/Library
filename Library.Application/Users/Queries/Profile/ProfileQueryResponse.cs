using Library.Domain.Entities;

namespace Library.Application.Users.Queries.Profile;

public record ProfileQueryResponse(
    string Login,
    IEnumerable<Book> Books);
