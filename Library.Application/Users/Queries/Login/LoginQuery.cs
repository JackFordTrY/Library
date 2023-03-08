using MediatR;

namespace Library.Application.Users.Queries.Login;

public class LoginQuery: IRequest<LoginQueryResponse>
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
