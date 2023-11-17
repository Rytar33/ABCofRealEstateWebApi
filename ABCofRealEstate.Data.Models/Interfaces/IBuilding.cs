using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Здания </summary>
    public interface IBuilding
    {
        /// <summary> Количество комнат </summary>
        public short CountRooms { get; set; }
        /// <summary> Объект находится на этаже... </summary>
        public short LocatedFloorApartament { get; set; }
        /// <summary> Количество этажей в здании </summary>
        public short CountFloorsHouse { get; set; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; set; }
        /// <summary> Материал здания </summary>
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Тип продажи (продажа/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
        /// <summary> Номер здания или дома </summary>
        public string NumberProperty { get; set; }
    }
}
