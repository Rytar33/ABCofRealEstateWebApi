namespace ABCofRealEstate.Services.Models.Moderators;

public class ModeratorLogInResponse
{
    public ModeratorLogInResponse(
        string token,
        Guid id)
    {
        Token = token;
        Id = id;
    }
    public string Token { get; init; }
    public Guid Id { get; init; }
}