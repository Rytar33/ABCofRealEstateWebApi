using ABCofRealEstate.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Rooms
{
    public class RoomCreateRequest
    {
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; set; } = true;
        public short CountRooms { get; set; } = 0;
        public short LocatedFloorApartament { get; set; } = 0;
        public short CountFloorsHouse { get; set; } = 0;
        public bool IsCorner { get; set; }
        public EnumMaterialHouse? MaterialHouse { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public string NumberProperty { get; set; } = null!;
        public double LivingSpace { get; set; } = 0;
        public double TotalArea { get; set; } = 0;
        public double KitchenArea { get; set; } = 0;
        public EnumConditionHouse? ConditionHouse { get; set; }
        public short NumberApartament { get; set; }
        public short CountBalcony { get; set; } = 0;
        public Guid? SourceRealEstateObjectId { get; set; }
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
