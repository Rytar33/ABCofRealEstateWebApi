using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Areas
{
    public class AreaChangeRequest
    {
        public AreaChangeRequest(
            Guid id,
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            int landArea,
            bool isActual)
        {
            Id = id;
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            LandArea = landArea;
            IsActual = isActual;
        }
        public AreaChangeRequest()
        {
            
        }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public Guid? EmployeeId { get; init; }
        public int LandArea { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public bool IsActual { get; init; }
    }
}
