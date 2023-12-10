using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Дом" </summary>
    public class House : IRealEstateObject, IBuilding, IResidentialProperty
    {
        /// <summary> Идентификатор дома </summary>
        [Key]
        [Display(Name = "ID_House")]
        public int IdHouse { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? IdsImg { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee? Employee { get; set; }
        public short CountRooms { get; set; } = 0;
        public short LocatedFloorApartament { get; set; }
        public short CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Состояние дома </summary>
        public EnumConditionHouse? ConditionHouse { get; set; }
        public double LivingSpace { get; set; } = 0;
        public double TotalArea { get; set; } = 0;
        public double KitchenArea { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) участка</summary>
        public double Area { get; set; } = 0.0;
        /// <summary> Площадь(сот.) огорода </summary>
        public double GardenSot { get; set; } = 0;
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
        public string NumberProperty { get; set; } = null!;
    }
}
