using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Идентификаторы объектов под недвижимость </summary>
    [Table("source_real_estate_object")]
    public class SourceRealEstateObject
    {
        public SourceRealEstateObject(EnumObject nameObject)
        {
            NameObject = nameObject;
        }
        /// <summary> Идентификатор объекта </summary>
        [Key]
        [Display(Name = "id")]
        public Guid Id { get; set; }
        /// <summary> Название объекта </summary>
        [Display(Name = "name_object")]
        public EnumObject NameObject { get; init; }
        public Apartment? Apartment { get; init; }
        public Area? Area { get; init; }
        public Comertion? Comertion { get; init; }
        public Garage? Garage { get; init; }
        public Hostel? Hostel { get; init; }
        public House? House { get; init; }
        public Room? Room { get; init; }
    }
}
