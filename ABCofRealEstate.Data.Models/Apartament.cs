using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Apartament : IRealEstateObject, IBuilding, IResidentialProperty, IRoomInBuilding
    {
        /// <summary> Идентификатор квартиры </summary>
        [Key]
        [Display(Name = "ID_Apartament")]
        public int IdApartament { get; set; }
        public short CountRooms { get; set; }
        public string? District { get; set; }
        public string Street { get; set; }
        public string NumberApartament { get; set; }
        public string NumberProperty { get; set; }
        public EnumConditionHouse? ConditionHouse { get; set; }
        public double LivingSpace { get; set; } = 0;
        public double TotalArea { get; set; } = 0;
        public double KitchenArea { get; set; } = 0;
        public short CountFloorsHouse { get; set; }
        public short LocatedFloorApartament { get; set; }
        public bool IsCorner { get; set; }
        public short CountBalcony { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
    }
}