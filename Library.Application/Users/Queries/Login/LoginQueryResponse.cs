using System.Security.Claims;

namespace Library.Application.Users.Queries.Login;

public class LoginQueryResponse
{
    public ClaimsPrincipal Principal { get; set; } = new();
}
