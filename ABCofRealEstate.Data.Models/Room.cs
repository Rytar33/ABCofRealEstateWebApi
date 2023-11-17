using System.ComponentModel.DataAnnotations;
using ABCofRealEstate.Data.Models.Interfaces;

namespace ABCofRealEstate.Data.Models
{
    public class Room : IRealEstateObject, IBuilding, IResidentialProperty, IRoomInBuilding
    {
        [Key]
        [Display(Name = "ID_Room")]
        public int IdRoom { get; set; }
    }
}
