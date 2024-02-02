using ABCofRealEstate.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageCreateRequest
    {
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Guid? IdEmployee { get; set; }
        public EnumLocality Locality { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public Guid? SourceRealEstateObjectId { get; set; }
        public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
