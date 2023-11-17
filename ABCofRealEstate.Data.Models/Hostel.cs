using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Hostel : IRealEstateObject, IBuilding, IResidentialProperty, IRoomInBuilding
    {
        /// <summary> Идентификатор общежития </summary>
        [Key]
        [Display(Name = "ID_Hostel")]
        public int IdHostel { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? URLImgs { get; set; }
        /// <summary> Площадь(в кв м) Жилая </summary>
        public int LivingSpace { get; set; } = 0;
        /// <summary> Площадь(в кв м) Общая </summary>
        public int TotalArea { get; set; } = 0;
        /// <summary> Площадь(в кв м) Кухни </summary>
        public int KitchenArea { get; set; } = 0;
        /// <summary> Описание общежития </summary>
        public string Description { get; set; }
        /// <summary> Цена </summary>
        public int Price { get; set; }
        /// <summary> Идентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
        /// <summary> Состояние общежития </summary>
        public EnumConditionHouse ConditionHouse { get; set; }
        public int CountRooms { get; set; }
        public int LocatedFloorApartament { get; set; }
        public int CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
