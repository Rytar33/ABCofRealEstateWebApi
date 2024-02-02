using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorListResponse
    {
        public IEnumerable<ModeratorListItem> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
