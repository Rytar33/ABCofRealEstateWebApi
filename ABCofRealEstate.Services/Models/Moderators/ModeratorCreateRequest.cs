namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorCreateRequest
    {
        public ModeratorCreateRequest(
            string name,
            string email,
            string password,
            EnumAccessLevel accessLevel)
        {
            Name = name;
            Email = email;
            Password = password;
            AccessLevel = accessLevel;
        }
        public ModeratorCreateRequest()
        {
            
        }
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public EnumAccessLevel AccessLevel { get; init; }
    }
}
