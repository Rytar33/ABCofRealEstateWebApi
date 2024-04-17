using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Гараж" </summary>
    [Table("garage")]
    public class Garage : IRealEstateObject
    {
        public Garage(
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality)
        {
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            ImportantInformation = description.ToString();
        }
        /// <summary> Идентификатор гаража </summary>
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
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; init; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; init; }

        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; init; } = DateTime.UtcNow;
        [Display(Name = "is_actual")]
        public bool IsActual { get; init; } = true;
        [NotMapped]
        public string ImportantInformation { get; init; }
    }
}
