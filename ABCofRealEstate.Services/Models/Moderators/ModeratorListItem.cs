using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorListItem
    {
        public Guid IdModerator { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public EnumAccessLevel AccessLevel { get; set; }
        public bool IsSuperModerator { get; set; }
    }
}
