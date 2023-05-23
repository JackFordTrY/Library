using Library.Domain.Entities;

namespace Library.Contracts.UserContracts;

public record ProfileResponse(
    string Login,
    List<Book> Books);
