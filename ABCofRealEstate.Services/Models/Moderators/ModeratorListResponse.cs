using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorListResponse
    {
        public ModeratorListResponse(
            IEnumerable<ModeratorListItem> items,
            PageResponse? page)
        {
            Items = items;
            Page = page;
        }
        public IEnumerable<ModeratorListItem> Items { get; init; }
        public PageResponse? Page { get; init; }
    }
}
