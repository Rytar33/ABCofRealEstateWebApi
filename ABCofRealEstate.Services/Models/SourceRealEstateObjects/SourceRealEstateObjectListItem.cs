using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListItem
    {
        public Guid IdSource { get; set; }
        public string? ImagePath { get; set; }
        public EnumLocality Locality { get; set; }
        public string ImportantInformation { get; set; } = null!;
        public int Price { get; set; }
    }
}
