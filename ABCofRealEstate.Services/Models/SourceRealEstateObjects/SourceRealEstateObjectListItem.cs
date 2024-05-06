namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListItem
    {
        public SourceRealEstateObjectListItem(
            Guid idSource,
            EnumObject typeObject,
            Guid idRealEstateObject,
            string? imagePath,
            EnumLocality locality,
            EnumTypeSale typeSale,
            string importantInformation,
            int price)
        {
            IdSource = idSource;
            TypeObject = typeObject;
            IdRealEstateObject = idRealEstateObject;
            ImagePath = imagePath;
            Locality = locality;
            ImportantInformation = importantInformation;
            TypeSale = typeSale;
            Price = price;
        }
        public Guid IdSource { get; init; }
        public EnumObject TypeObject { get; init; }
        public Guid IdRealEstateObject { get; init; }
        public string? ImagePath { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public string ImportantInformation { get; init; }
        public int Price { get; init; }
    }
}
