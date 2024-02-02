using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Комната" </summary>
    [Table("room")]
    public class Room : IRealEstateObject, IBuilding, IResidentialProperty, IRoomInBuilding
    {
        /// <summary> Идентификатор комнаты </summary>
        [Display(Name = "id")]
        public Guid Id { get; set; }
        [Display(Name = "district")]
        public string? District { get; set; }
        [Display(Name = "street")]
        public string? Street { get; set; }
        [ForeignKey("SourceRealEstateObject")]
        [Display(Name = "source_real_estate_object_id")]
        public Guid SourceRealEstateObjectId { get; set; }
        public SourceRealEstateObject? SourceRealEstateObject { get; set; }
        [Display(Name = "description")]
        public string? Description { get; set; }
        [Display(Name = "price")]
        public int Price { get; set; }
        [ForeignKey("Employee")]
        [Display(Name = "employee_id")]
        public Guid? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; set; }
        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; set; }
        [Display(Name = "is_actual")]
        public bool IsActual { get; set; } = true;
        [Display(Name = "count_rooms")]
        public short CountRooms { get; set; } = 0;
        [Display(Name = "located_floor_apartament")]
        public short LocatedFloorApartament { get; set; } = 0;
        [Display(Name = "count_floor_house")]
        public short CountFloorsHouse { get; set; } = 0;
        [Display(Name = "is_corner")]
        public bool IsCorner { get; set; }
        [Display(Name = "material_house")]
        public EnumMaterialHouse? MaterialHouse { get; set; }
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; set; }
        [Display(Name = "number_property")]
        public string NumberProperty { get; set; } = null!;
        [Display(Name = "living_space")]
        public double LivingSpace { get; set; } = 0;
        [Display(Name = "total_area")]
        public double TotalArea { get; set; } = 0;
        [Display(Name = "kitchen_area")]
        public double KitchenArea { get; set; } = 0;
        [Display(Name = "condition_house")]
        public EnumConditionHouse? ConditionHouse { get; set; }
        [Display(Name = "number_apartament")]
        public short NumberApartament { get; set; }
        [Display(Name = "count_balcony")]
        public short CountBalcony { get; set; } = 0;
    }
}
