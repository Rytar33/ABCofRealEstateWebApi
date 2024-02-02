using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Идентификаторы объектов под недвижимость </summary>
    [Table("source_real_estate_object")]
    public class SourceRealEstateObject
    {
        /// <summary> Идентификатор объекта </summary>
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; set; }
        /// <summary> Название объекта </summary>
        [Display(Name = "name_object")]
        public EnumObject NameObject { get; set; }
    }
}
