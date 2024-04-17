using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Hostels
{
    public class HostelDetailResponse
    {
        public HostelDetailResponse(
            Guid id,
            short countRooms,
            string? district,
            string? street,
            short numberApartment,
            string numberProperty,
            EnumConditionHouse? conditionHouse,
            decimal livingSpace,
            decimal totalArea,
            decimal kitchenArea,
            bool isCorner,
            short countFloorsHouse,
            short locatedFloorApartment,
            short countBalcony,
            EnumMaterialHouse? materialHouse,
            string description,
            int price,
            EmployeeDetailResponse? employee,
            EnumTypeSale typeSale,
            EnumLocality locality,
            bool isActual,
            DateTime dateTimePublished,
            string[] fullPathsImage)
        {
            Id = id;
            CountRooms = countRooms;
            District = district;
            Street = street;
            NumberProperty = numberProperty;
            NumberApartment = numberApartment;
            ConditionHouse = conditionHouse;
            LivingSpace = livingSpace;
            TotalArea = totalArea;
            KitchenArea = kitchenArea;
            IsCorner = isCorner;
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            CountBalcony = countBalcony;
            MaterialHouse = materialHouse;
            Description = description;
            Price = price;
            Employee = employee;
            TypeSale = typeSale;
            Locality = locality;
            IsActual = isActual;
            DateTimePublished = dateTimePublished;
            FullPathsImage = fullPathsImage;
        }
        public string[] FullPathsImage { get; init; }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public decimal LivingSpace { get; init; }
        public decimal TotalArea { get; init; }
        public decimal KitchenArea { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public EmployeeDetailResponse? Employee { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumConditionHouse? ConditionHouse { get; init; }
        public short CountRooms { get; init; }
        public short LocatedFloorApartment { get; init; }
        public short CountFloorsHouse { get; init; }
        public bool IsCorner { get; init; }
        public EnumMaterialHouse? MaterialHouse { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public DateTime DateTimePublished { get; set; }
        public bool IsActual { get; init; }
        public string NumberProperty { get; init; }
        public short NumberApartment { get; init; }
        public short CountBalcony { get; init; }
    }
}
