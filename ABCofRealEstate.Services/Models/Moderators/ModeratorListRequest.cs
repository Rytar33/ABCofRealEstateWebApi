using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorListRequest
    {
        public string? Search { get; set; }
        public bool? IsSuperModerator { get; set; }
        public EnumAccessLevel? AccessLevel { get; set; }
        public PageRequest? Page { get; set; }
    }
}
