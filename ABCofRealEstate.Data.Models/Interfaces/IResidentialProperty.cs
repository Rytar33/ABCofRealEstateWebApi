using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Жилая недвижимость </summary>
    public interface IResidentialProperty : IBuilding
    {
        /// <summary> Площадь(в кв. м.) жилая </summary>
        public decimal LivingSpace { get; init; }
        /// <summary> Площадь(в кв. м.) общая </summary>
        public decimal TotalArea { get; init; }
        /// <summary> Площадь(в кв. м.) кухни </summary>
        public decimal KitchenArea { get; init; }
        /// <summary> Состояние дома </summary>
        public EnumConditionHouse? ConditionHouse { get; init; }
    }
}
