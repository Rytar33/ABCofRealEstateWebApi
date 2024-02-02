using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Areas
{
    public class AreaChangeRequest
    {
        public Guid IdArea { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? EmployeeId { get; set; }
        public int LandArea { get; set; }
        public EnumLocality Locality { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
