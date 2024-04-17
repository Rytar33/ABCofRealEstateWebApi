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
            ICollection<IFormFile> files)
        {
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
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
        public ICollection<IFormFile> Files { get; init; }
    }
}
