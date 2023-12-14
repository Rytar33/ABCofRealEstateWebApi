using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Areas
{
    public class AreaCreateRequest
    {
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? IdsImg { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        public int LandArea { get; set; }
        public EnumLocality Locality { get; set; }
    }
}
