using ABCofRealEstate.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Hostels
{
    public class HostelCreateRequest
    {
        public string? District { get; set; }
        public string? Street { get; set; }
        public double LivingSpace { get; set; }
        public double TotalArea { get; set; }
        public double KitchenArea { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public EnumLocality Locality { get; set; }
        public EnumConditionHouse? ConditionHouse { get; set; }
        public short CountRooms { get; set; }
        public short LocatedFloorApartament { get; set; }
        public short CountFloorsHouse { get; set; }
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public string NumberProperty { get; set; } = null!;
        public short NumberApartament { get; set; }
        public short CountBalcony { get; set; }
        public Guid? SourceRealEstateObjectId { get; set; }
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
