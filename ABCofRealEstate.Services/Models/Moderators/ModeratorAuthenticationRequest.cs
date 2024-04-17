namespace ABCofRealEstate.Services.Models.Moderators;

public class ModeratorAuthenticationRequest
{
    public ModeratorAuthenticationRequest(
        string emailOrName,
        string password)
    {
        EmailOrName = emailOrName;
        Password = password;
    }
    public ModeratorAuthenticationRequest()
    {
            
    }
    public string EmailOrName { get; init; }
    public string Password { get; init; }
}