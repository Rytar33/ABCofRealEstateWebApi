using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Участок" </summary>
    [Table("area")]
    public class Area : IRealEstateObject
    {
        public Area(
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            int landArea,
            decimal latitude,
            decimal longitude)
        {
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            LandArea = landArea;
            Latitude = latitude;
            Longitude = longitude;
            ImportantInformation = landArea.ToString();
        }
        /// <summary> Идентификатор участка </summary>
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
        /// <summary> Площадь участка(сот.) </summary>
        [Display(Name = "land_area")]
        public int LandArea { get; init; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; init; }
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; init; }
        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; init; } = DateTime.UtcNow;
        [Display(Name = "is_actual")]
        public bool IsActual { get; init; } = true;
        [NotMapped]
        public string ImportantInformation { get; init; }
        
        [Display(Name = "latitude")]
        public decimal Latitude { get; init; }
        
        [Display(Name = "longitude")]
        public decimal Longitude { get; init; }
    }
}
