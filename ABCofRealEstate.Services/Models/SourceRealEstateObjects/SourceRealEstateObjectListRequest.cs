using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListRequest
    {
        public SourceRealEstateObjectListRequest(
            EnumObject? typeObject = null,
            EnumLocality? locality = null,
            int? priceFrom = null,
            int? priceTo = null,
            PageRequest? page = null)
        {
            TypeObject = typeObject;
            Locality = locality;
            PriceFrom = priceFrom;
            PriceTo = priceTo;
            Page = page ?? new PageRequest();
        }

        public SourceRealEstateObjectListRequest()
        {
            Page ??= new PageRequest();
        }
        public EnumObject? TypeObject { get; init; }
        public EnumLocality? Locality { get; init; }
        public int? PriceFrom { get; init; }
        public int? PriceTo { get; init; }
        public PageRequest? Page { get; init; }
    }
}
