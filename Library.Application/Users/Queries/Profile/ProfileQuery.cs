using MediatR;

namespace Library.Application.Users.Queries.Profile; 

public class ProfileQuery: IRequest
{
    public string Login { get; set; } = string.Empty;
}
