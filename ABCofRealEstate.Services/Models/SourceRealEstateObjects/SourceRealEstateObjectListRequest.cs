using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectListRequest
    {
        public EnumObject? TypeObject { get; set; }
        public EnumLocality? Locality { get; set; }
        public PageRequest? Page { get; set; }
    }
}
