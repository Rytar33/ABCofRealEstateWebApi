using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Area : IRealEstateObject
    {
        /// <summary> Идентификатор участка </summary>
        [Key]
        [Display(Name = "ID_Area")]
        public int IdArea { get; set; }
        /// <summary> Район </summary>
        public string? District { get; set; }
        /// <summary> Улица </summary>
        public string Street { get; set; }
        /// <summary> Ссылки на изображении участка </summary>
        public string? URLImgs { get; set; }
        /// <summary> Описание участка </summary>
        public string Description { get; set; }
        /// <summary> Цена за участок </summary>
        public int Price { get; set; }
        /// <summary> Индентификатор агента недвижимости </summary>
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        /// <summary> Площадь участка(сот.) </summary>
        public int LandArea { get; set; }
        /// <summary> Населённый пункт </summary>
        public EnumLocality Locality { get; set; }
    }
}
