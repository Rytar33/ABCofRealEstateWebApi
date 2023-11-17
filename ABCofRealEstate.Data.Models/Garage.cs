using ABCofRealEstate.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABCofRealEstate.Data.Models
{
    public class Garage : IRealEstateObject
    {
        [Key]
        [Display(Name = "ID_Garage")]
        public int IdGarage { get; set; }
        public string? District { get; set; }
        public string Street { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Employee Employee { get; set; }
        public EnumLocality Locality { get; set; }
    }
}
