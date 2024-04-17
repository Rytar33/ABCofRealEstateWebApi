namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorDetailResponse
    {
        public ModeratorDetailResponse(
            Guid id,
            string name,
            string email,
            EnumAccessLevel accessLevel,
            bool isSuperModerator)
        {
            Id = id;
            Name = name;
            Email = email;
            AccessLevel = accessLevel;
            IsSuperModerator = isSuperModerator;
        }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public EnumAccessLevel AccessLevel { get; init; }
        public bool IsSuperModerator { get; init; }
    }
}
