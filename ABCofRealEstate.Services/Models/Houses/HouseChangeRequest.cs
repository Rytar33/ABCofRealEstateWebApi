using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Houses
{
    public class HouseChangeRequest
    {
        public Guid IdHouse { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public short CountRooms { get; set; } = 0;
        public short LocatedFloorApartament { get; set; }
        public short CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumConditionHouse? ConditionHouse { get; set; }
        public double LivingSpace { get; set; } = 0;
        public double TotalArea { get; set; } = 0;
        public double KitchenArea { get; set; } = 0;
        public double Area { get; set; } = 0.0;
        public double GardenSot { get; set; } = 0;
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public string NumberProperty { get; set; } = null!;
        public bool IsActual { get; set; }
    }
}
