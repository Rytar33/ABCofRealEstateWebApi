using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListResponse
    {
        public SourceRealEstateObjectListResponse(
            IEnumerable<SourceRealEstateObjectListItem> items,
            PageResponse? page)
        {
            Items = items;
            Page = page;
        }
        public IEnumerable<SourceRealEstateObjectListItem> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
