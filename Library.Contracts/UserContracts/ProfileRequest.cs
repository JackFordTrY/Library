namespace Library.Contracts.UserContracts;

public class ProfileRequest
{
    public string Login { get; set; } = string.Empty;

    public string ProfilePicture { get; set; } = string.Empty;
}
