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
        /// <summary> Идентификатор участка </summary>
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
        /// <summary> Площадь участка(сот.) </summary>
        [Display(Name = "land_area")]
        public int LandArea { get; set; }
        [Display(Name = "locality")]
        public EnumLocality Locality { get; set; }
        [Display(Name = "type_sale")]
        public EnumTypeSale TypeSale { get; set; }
        [Display(Name = "date_time_published")]
        public DateTime DateTimePublished { get; set; }
        [Display(Name = "is_actual")]
        public bool IsActual { get; set; } = true;
    }
}
