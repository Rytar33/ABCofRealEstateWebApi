using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Общежитие" </summary>
    public class Hostel : IRealEstateObject, IBuilding, IResidentialProperty, IRoomInBuilding
    {
        /// <summary> Идентификатор общежития </summary>
        [Key]
        [Display(Name = "ID_Hostel")]
        public int IdHostel { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? IdsImg { get; set; }
        public double LivingSpace { get; set; } = 0;
        public double TotalArea { get; set; } = 0;
        public double KitchenArea { get; set; } = 0;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee? Employee { get; set; }
        public EnumLocality Locality { get; set; }
        public EnumConditionHouse? ConditionHouse { get; set; }
        public short CountRooms { get; set; } = 0;
        public short LocatedFloorApartament { get; set; } = 0;
        public short CountFloorsHouse { get; set; } = 0;
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
        public string NumberProperty { get; set; } = null!;
        public short NumberApartament { get; set; }
        public short CountBalcony { get; set; } = 0;
    }
}
