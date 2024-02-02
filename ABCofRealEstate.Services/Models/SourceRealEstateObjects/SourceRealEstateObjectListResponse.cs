using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListResponse
    {
        public IEnumerable<SourceRealEstateObjectListItem> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
