using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Areas
{
    public class AreaCreateRequest
    {
        public AreaCreateRequest(
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            int landArea,
            decimal latitude,
            decimal longitude,
            ICollection<IFormFile> files)
        {
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            LandArea = landArea;
            Latitude = latitude;
            Longitude = longitude;
            Files = files;
        }

        public AreaCreateRequest()
        {
            
        }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public Guid? EmployeeId { get; init; }
        public int LandArea { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public ICollection<IFormFile> Files { get; init; }
    }
}
