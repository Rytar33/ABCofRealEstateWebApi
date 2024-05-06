namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorDetailResponse
    {
        public ModeratorDetailResponse(
            Guid id,
            string name,
            string email,
            bool isSuperModerator)
        {
            Id = id;
            Name = name;
            Email = email;
            IsSuperModerator = isSuperModerator;
        }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public bool IsSuperModerator { get; init; }
    }
}
