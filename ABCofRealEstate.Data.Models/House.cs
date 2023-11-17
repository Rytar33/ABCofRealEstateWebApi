using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class House : IRealEstateObject, IBuilding, IResidentialProperty
    {
        /// <summary> Идентификатор дома </summary>
        [Key]
        [Display(Name = "ID_House")]
        public int IdHouse { get; set; }
        public string? District { get; set; }
        public string Street { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        public int CountRooms { get; set; }
        public int LocatedFloorApartament { get; set; }
        public int CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Состояние дома </summary>
        public EnumConditionHouse? ConditionHouse { get; set; }
        /// <summary> Площадь(в кв. м.) жилая </summary>
        public int LivingSpace { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) общая </summary>
        public int TotalArea { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) кухни </summary>
        public int KitchenArea { get; set; } = 0;
        /// <summary> Площадь(в кв. м.) участка</summary>
        public double Area { get; set; }
        /// <summary> Площадь(сот.) огорода </summary>
        public int GardenSot { get; set; }
        /// <summary> Тип продажи (продажа/сдача в аренду) </summary>
        public EnumTypeSale TypeSale { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
