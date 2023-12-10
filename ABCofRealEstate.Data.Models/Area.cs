using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    /// <summary> Модель класса "Участок" </summary>
    public class Area : IRealEstateObject
    {
        /// <summary> Идентификатор участка </summary>
        [Key]
        [Display(Name = "ID_Area")]
        public int IdArea { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? IdsImg { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee? Employee { get; set; }
        /// <summary> Площадь участка(сот.) </summary>
        public int LandArea { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
    }
}
