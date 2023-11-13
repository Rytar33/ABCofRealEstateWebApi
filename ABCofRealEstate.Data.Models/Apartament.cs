using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models
{
    public class Apartament : IRealEstateObject, IBuilding
    {
        public int IdApartament { get; set; }
        public int CountRooms { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string NumberHouse { get; set; }
        public EnumConditionHouse ConditionHouse { get; set; }
        public int LivingSpace { get; set; } = 0;
        public int TotalArea { get; set; } = 0;
        public int KitchenArea { get; set; } = 0;
        public int CountFloorsHouse { get; set; }
        public int LocatedFloorApartament { get; set; }
        public bool IsCorner { get; set; }
        public int CountBalcony { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        public Employee Employee { get; set; }
        public EnumTypeSale TypeSale { get; set; }
    }
}