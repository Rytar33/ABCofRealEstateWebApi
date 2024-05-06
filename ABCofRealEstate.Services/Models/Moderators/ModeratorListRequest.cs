using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Moderators
{
    public class ModeratorListRequest
    {
        public ModeratorListRequest(
            string? search,
            bool? isSuperModerator,
            PageRequest? page)
        {
            Search = search;
            IsSuperModerator = isSuperModerator;
            Page = page ?? new PageRequest();
        }
        public ModeratorListRequest()
        {
            Page ??= new PageRequest();
        }
        public string? Search { get; init; }
        public bool? IsSuperModerator { get; init; }
        public PageRequest? Page { get; init; }
    }
}
