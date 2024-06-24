using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListResponse
    {
        public SourceRealEstateObjectListResponse(
            IEnumerable<SourceRealEstateObjectListItem> items,
            PageResponse? page,
            int maxPrice)
        {
            Items = items;
            Page = page;
            MaxPrice = maxPrice;
        }
        public IEnumerable<SourceRealEstateObjectListItem> Items { get; set; }
        public int MaxPrice { get; set; } = 0;
        public PageResponse? Page { get; set; }
    }
}
