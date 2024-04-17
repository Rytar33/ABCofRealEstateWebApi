using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Здания </summary>
    public interface IBuilding
    {
        /// <summary> Количество комнат </summary>
        public short CountRooms { get; init; }
        /// <summary> Объект находится на этаже... </summary>
        public short LocatedFloorApartment { get; init; }
        /// <summary> Количество этажей в здании </summary>
        public short CountFloorsHouse { get; init; }
        /// <summary> Угловая? </summary>
        public bool IsCorner { get; init; }
        /// <summary> Материал здания </summary>
        public EnumMaterialHouse? MaterialHouse { get; init; }
        /// <summary> Номер здания или дома </summary>
        public string NumberProperty { get; init; }
    }
}
