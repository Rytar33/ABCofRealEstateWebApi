using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Дом" </summary>
    [Table("house")]
    public class House : IRealEstateObject, IResidentialProperty
    {
        public House(
            short countRooms,
            string? district,
            string? street,
            string numberProperty,
            EnumConditionHouse? conditionHouse,
            decimal livingSpace,
            decimal totalArea,
            decimal kitchenArea,
            short countFloorsHouse,
            short locatedFloorApartment,
            bool isCorner,
            EnumMaterialHouse? materialHouse,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal gardenSot,
            decimal area)
        {
            CountRooms = countRooms;
            District = district;
            Street = street;
            NumberProperty = numberProperty;
            ConditionHouse = conditionHouse;
            LivingSpace = livingSpace;
            TotalArea = totalArea;
            KitchenArea = kitchenArea;
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            IsCorner = isCorner;
            MaterialHouse = materialHouse;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            GardenSot = gardenSot;
            Area = area;
            ImportantInformation = totalArea.ToString(CultureInfo.InvariantCulture);
        }
        /// <summary> Идентификатор дома </summary>
        [Display(Name = "id")]
        public Guid Id { get; set; }
        [Display(Name = "district")]
        public string? District { get; init; }
        [Display(Name = "street")]
        public string? Street { get; init; }
        [ForeignKey("SourceRealEstateObject")]
        [Display(Name = "source_real_estate_object_id")]
        public Guid SourceRealEstateObjectId { get; init; }
        public SourceRealEstateObject? SourceRealEstateObject { get; init; }
        [Display(Name = "description")]
        public string? Description { get; init; }
        [Display(Name = "price")]
        public int Price { get; init; }
        [ForeignKey("Employee")]
        [Display(Name = "employee_id")]
        public Guid? EmployeeId { get; init; }
        public Employee? Employee { get; init; }
        [Display(Name = "count_rooms")]
        public short CountRooms { get; init; }
        [Display(Name = "located_floor_apartment")]
        public short LocatedFloorApartment { get; init; }
        [Display(Name = "count_floor_house")]
        public short CountFloorsHouse { get; init; }
        [Display(Name = "is_corner")]
        public bool IsCorner { get; init; }
        [Display(Name = "material_house")]
        public EnumMaterialHouse? MaterialHouse { get; init; }
        [Display(Name = "condition_house")]
        public EnumConditionHouse? ConditionHouse { get; init; }
        [Display(Name = "living_space")]
        public decimal LivingSpace { get; init; }
        [Display(Name = "total_area")]
        public decimal TotalArea { get; init; }
        [Display(Name = "kitchen_area")]
        public decimal KitchenArea { get; init; }
        /// <summary> Площадь(в кв. м.) участка</summary>
        [Display(Name = "area")]
        public decimal Area { get; init; }
        /// <summary> Площадь(сот.) огорода </summary>
        [Display(Name = "garden_sot")]
        public decimal GardenSot { get; init; }
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; init; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; init; }

        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; init; } = DateTime.UtcNow;
        [Display(Name = "is_actual")]
        public bool IsActual { get; init; } = true;
        [Display(Name = "number_property")]
        public string NumberProperty { get; init; }
        [NotMapped]
        public string ImportantInformation { get; init; }
    }
}
