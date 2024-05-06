using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListRequest
    {
        public SourceRealEstateObjectListRequest(
            EnumObject? typeObject = null,
            EnumLocality? locality = null,
            EnumTypeSale? typeSale = null,
            int? priceFrom = null,
            int? priceTo = null,
            bool isActual = true,
            PageRequest? page = null)
        {
            TypeObject = typeObject;
            Locality = locality;
            TypeSale = typeSale;
            PriceFrom = priceFrom;
            PriceTo = priceTo;
            IsActual = isActual;
            Page = page ?? new PageRequest();
        }

        public SourceRealEstateObjectListRequest()
        {
            Page ??= new PageRequest();
        }
        public EnumObject? TypeObject { get; init; }
        public EnumLocality? Locality { get; init; }
        public EnumTypeSale? TypeSale { get; init; }
        public int? PriceFrom { get; init; }
        public int? PriceTo { get; init; }
        public bool IsActual { get; init; } = true;
        public PageRequest? Page { get; init; }
    }
}
