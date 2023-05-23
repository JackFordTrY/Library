using MediatR;

namespace Library.Application.Users.Queries.Profile; 

public class ProfileQuery: IRequest<ProfileQueryResponse>
{
    public string Login { get; set; } = string.Empty;
}
