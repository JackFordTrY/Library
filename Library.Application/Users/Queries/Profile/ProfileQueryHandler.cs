using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Users.Queries.Profile;

public class ProfileQueryHandler : IRequestHandler<ProfileQuery, ProfileQueryResponse>
{
    private readonly IUserRepository _userRepository;

    public ProfileQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ProfileQueryResponse> Handle(ProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByLoginAsync(request.Login);

        return new ProfileQueryResponse(user!.Login, user.BooksMarked);
    }
}
