namespace ABCofRealEstate.Services.Models.Moderators;

public class ModeratorLogInResponse
{
    public ModeratorLogInResponse(
        string token,
        Guid id,
        string name,
        string email,
        EnumAccessLevel accessLevel,
        bool isSuperModerator)
    {
        Token = token;
        Id = id;
        Name = name;
        Email = email;
        AccessLevel = accessLevel;
        IsSuperModerator = isSuperModerator;
    }
    public string Token { get; private init; }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public EnumAccessLevel AccessLevel { get; init; }
    public bool IsSuperModerator { get; init; }
}