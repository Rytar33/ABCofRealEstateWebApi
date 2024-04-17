using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageDetailResponse
    {
        public GarageDetailResponse(
            Guid id,
            string? district,
            string? street,
            string description,
            int price,
            EmployeeDetailResponse? employee,
            EnumTypeSale typeSale,
            EnumLocality locality,
            DateTime dateTimePublished,
            bool isActual,
            string[] fullPathsImage)
        {
            Id = id;
            District = district;
            Street = street;
            Description = description;
            Price = price;
            Employee = employee;
            TypeSale = typeSale;
            Locality = locality;
            DateTimePublished = dateTimePublished;
            IsActual = isActual;
            FullPathsImage = fullPathsImage;
        }
        public string[] FullPathsImage { get; init; }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public EmployeeDetailResponse? Employee { get; init; }
        public EnumLocality Locality { get; init; }
        public DateTime DateTimePublished { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public bool IsActual { get; init; }
    }
}
