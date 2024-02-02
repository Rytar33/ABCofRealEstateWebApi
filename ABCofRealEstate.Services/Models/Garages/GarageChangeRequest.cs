using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageChangeRequest
    {
        public Guid IdGarage { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public EnumLocality Locality { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
