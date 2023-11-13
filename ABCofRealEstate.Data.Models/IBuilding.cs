using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models
{
    public interface IBuilding
    {
        public int CountRooms { get; set; }
        public int LocatedFloorApartament { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumTypeSale TypeSale { get; set; }
    }
}
