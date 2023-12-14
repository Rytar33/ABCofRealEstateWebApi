using ABCofRealEstate.Data.Enums;
namespace ABCofRealEstate.Services.Models.Apartaments
{
    public class ApartamentCreateRequest
    {
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
        public string? IdsImg { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
    }
}
