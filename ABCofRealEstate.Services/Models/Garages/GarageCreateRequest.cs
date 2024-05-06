using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageCreateRequest
    {
        public GarageCreateRequest(
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            short garageCapacity,
            bool haveBasement,
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
            GarageCapacity = garageCapacity;
            HaveBasement = haveBasement;
            Latitude = latitude;
            Longitude = longitude;
            Files = files;
        }
        public GarageCreateRequest()
        {
            
        }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public Guid? EmployeeId { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public short GarageCapacity { get; init; }
        public bool HaveBasement { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public ICollection<IFormFile> Files { get; init; }
    }
}
