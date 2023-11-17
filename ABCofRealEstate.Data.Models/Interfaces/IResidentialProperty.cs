using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Жилая недвижимость </summary>
    public interface IResidentialProperty : IBuilding
    {
        /// <summary> Площадь(в кв. м.) жилая </summary>
        public double LivingSpace { get; set; }
        /// <summary> Площадь(в кв. м.) общая </summary>
        public double TotalArea { get; set; }
        /// <summary> Площадь(в кв. м.) кухни </summary>
        public double KitchenArea { get; set; }
        /// <summary> Состояние дома </summary>
        public EnumConditionHouse? ConditionHouse { get; set; }
    }
}
