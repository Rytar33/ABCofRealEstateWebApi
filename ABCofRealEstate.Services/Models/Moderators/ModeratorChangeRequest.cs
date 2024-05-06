namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorChangeRequest
    {
        public ModeratorChangeRequest(
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
        public ModeratorChangeRequest()
        {
            
        }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public bool IsSuperModerator { get; init; }
    }
}
