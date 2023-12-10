using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models;

namespace ABCofRealEstate.Services.Models.Lists
{
    public class ObjectListItem
    {
        public Image? FirstImage { get; set; }
        public EnumLocality Locality { get; set; }
        public string ImportantInformation { get; set; } = null!;
        public int Price { get; set; }
    }
}
