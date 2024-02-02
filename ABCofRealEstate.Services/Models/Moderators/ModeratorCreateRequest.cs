using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorCreateRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public EnumAccessLevel AccessLevel { get; set; }
    }
}
