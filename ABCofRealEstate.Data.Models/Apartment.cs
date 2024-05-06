using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Квартира" </summary>
    [Table("apartment")]
    public class Apartment : IRealEstateObject, IRoomInBuilding
    {
        public Apartment(
            short countRooms,
            string? district,
            string? street,
            short numberApartment,
            string numberProperty,
            EnumConditionHouse? conditionHouse,
            decimal livingSpace,
            decimal totalArea,
            decimal kitchenArea,
            short countFloorsHouse,
            short locatedFloorApartment,
            bool isCorner,
            short countBalcony,
            EnumMaterialHouse? materialHouse,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal latitude,
            decimal longitude)
        {
            CountRooms = countRooms;
            District = district;
            Street = street;
            NumberProperty = numberProperty;
            NumberApartment = numberApartment;
            ConditionHouse = conditionHouse;
            LivingSpace = livingSpace;
            TotalArea = totalArea;
            KitchenArea = kitchenArea;
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            IsCorner = isCorner;
            CountBalcony = countBalcony;
            MaterialHouse = materialHouse;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            Latitude = latitude;
            Longitude = longitude;
            ImportantInformation = countRooms.ToString();
        }

        /// <summary> Идентификатор квартиры </summary>
        [Display(Name = "id")]
        public Guid Id { get; set; }
        [Display(Name = "count_rooms")]
        public short CountRooms { get; init; }
        [Display(Name = "district")]
        public string? District { get; init; }
        [Display(Name = "street")]
        public string? Street { get; init; }
        [Display(Name = "number_apartment")]
        public short NumberApartment { get; init; }
        [Display(Name = "number_property")]
        public string NumberProperty { get; init; }
        [Display(Name = "condition_house")]
        public EnumConditionHouse? ConditionHouse { get; init; }
        [Display(Name = "living_space")]
        public decimal LivingSpace { get; init; } = 0;
        [Display(Name = "total_area")]
        public decimal TotalArea { get; init; } = 0;
        [Display(Name = "kitchen_area")]
        public decimal KitchenArea { get; init; } = 0;
        public short CountFloorsHouse { get; init; }
        [Display(Name = "located_floor_apartment")]
        public short LocatedFloorApartment { get; init; }
        [Display(Name = "is_corner")]
        public bool IsCorner { get; init; }
        [Display(Name = "count_balcony")]
        public short CountBalcony { get; init; } = 0;
        [Display(Name = "material_house")]
        public EnumMaterialHouse? MaterialHouse { get; init; }
        [ForeignKey("SourceRealEstateObject")]
        [Display(Name = "source_real_estate_object_id")]
        public Guid SourceRealEstateObjectId { get; init; }
        public SourceRealEstateObject? SourceRealEstateObject { get; init; }
        
        [Display(Name = "description")]
        public string Description { get; init; }
        [Display(Name = "price")]
        public int Price { get; init; }
        [ForeignKey("Employee")]
        [Display(Name = "employee_id")]
        public Guid? EmployeeId { get; init; }
        public Employee? Employee { get; init; }
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; init; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; init; }

        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; init; } = DateTime.UtcNow;
        [Display(Name = "is_actual")]
        public bool IsActual { get; set; } = true;
        [NotMapped]
        public string ImportantInformation { get; init; }
        
        [Display(Name = "latitude")]
        public decimal Latitude { get; init; }
        
        [Display(Name = "longitude")]
        public decimal Longitude { get; init; }
    }
}