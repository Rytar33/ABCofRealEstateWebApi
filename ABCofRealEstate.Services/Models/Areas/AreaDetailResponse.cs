using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Areas
{
    public class AreaDetailResponse
    {
        public AreaDetailResponse(
            string[] fullPathsImage,
            Guid id,
            string? district,
            string? street,
            string description,
            int price,
            EmployeeDetailResponse? employee,
            EnumTypeSale typeSale,
            EnumLocality locality,
            int landArea,
            bool isActual,
            DateTime dateTimePublished)
        {
            FullPathsImage = fullPathsImage;
            Id = id;
            District = district;
            Street = street;
            Description = description;
            Price = price;
            Employee = employee;
            TypeSale = typeSale;
            Locality = locality;
            LandArea = landArea;
            IsActual = isActual;
            DateTimePublished = dateTimePublished;
        }
        public string[] FullPathsImage { get; init; }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public EmployeeDetailResponse? Employee { get; init; }
        public int LandArea { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public DateTime DateTimePublished { get; init; }
        public bool IsActual { get; init; }
    }
}
