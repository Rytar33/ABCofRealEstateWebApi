using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Объект под коммерцию" </summary>
    public class Commertion : IRealEstateObject, IBuilding
    {
        /// <summary> Идентификатор объекта коммерции </summary>
        [Key]
        [Display(Name = "ID_Commertion")]
        public int IdCommertion { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? IdsImg { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee? Employee { get; set; }
        public short CountRooms { get; set; }
        public short LocatedFloorApartament { get; set; }
        public short CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        /// <summary> Площадь помещения </summary>
        public double RoomArea { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
        public string NumberProperty { get; set; } = null!;
    }
}
