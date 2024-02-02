using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageDetailResponse
    {
        public string[] FullPathsImage { get; set; } = Array.Empty<string>();
        public Guid IdGarage { get; set; }
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public EmployeeDetailResponse? Employee { get; set; }
        public EnumLocality Locality { get; set; }
        public DateTime DateTimePublished { get; set; }
        public EnumTypeSale TypeSale { get; set; }
        public bool IsActual { get; set; }
    }
}
