using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models
{
    public class Commertion : IRealEstateObject, IBuilding
    {
        public string District { get; set; }
        public string Street { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        public Employee Employee { get; set; }
        public int CountRooms { get; set; }
        public int LocatedFloorApartament { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public int RoomArea { get; set; }
        public EnumTypeSale TypeSale { get; set; }
    }
}
