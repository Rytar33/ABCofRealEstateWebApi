using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Commertions
{
    public class CommertionChangeRequest
    {
        public Guid IdCommertion { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public short CountRooms { get; set; }
        public short LocatedFloorApartament { get; set; }
        public short CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public double RoomArea { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public string NumberProperty { get; set; } = null!;
        public bool IsActual { get; set; } = true;
    }
}
