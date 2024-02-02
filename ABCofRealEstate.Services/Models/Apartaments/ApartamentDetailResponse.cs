using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Apartaments
{
    public class ApartamentDetailResponse
    {
        public string[] FullPathsImage { get; set; } = Array.Empty<string>();
        public Guid IdApartament { get; set; }
        public short CountRooms { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public short NumberApartament { get; set; }
        public string NumberProperty { get; set; } = null!;
        public EnumConditionHouse? ConditionHouse { get; set; }
        public double LivingSpace { get; set; }
        public double TotalArea { get; set; }
        public double KitchenArea { get; set; }
        public short CountFloorsHouse { get; set; }
        public short LocatedFloorApartament { get; set; }
        public bool IsCorner { get; set; }
        public short CountBalcony { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public EmployeeDetailResponse? Employee { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; }
    }
}
