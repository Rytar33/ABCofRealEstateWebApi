using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Apartments
{
    public class ApartmentDetailResponse
    {
        public ApartmentDetailResponse(
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
            short countFloorsHouse,
            short locatedFloorApartment,
            bool isCorner,
            short countBalcony,
            EnumMaterialHouse? materialHouse,
            string description,
            int price,
            EmployeeDetailResponse? employee,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal latitude,
            decimal longitude,
            string[] fullPathsImage,
            bool isActual,
            DateTime dateTimePublished)
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
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            IsCorner = isCorner;
            CountBalcony = countBalcony;
            MaterialHouse = materialHouse;
            Description = description;
            Price = price;
            Employee = employee;
            TypeSale = typeSale;
            Locality = locality;
            Latitude = latitude;
            Longitude = longitude;
            FullPathsImage = fullPathsImage;
            IsActual = isActual;
            DateTimePublished = dateTimePublished;
        }
        public string[] FullPathsImage { get; init; }
        public Guid Id { get; init; }
        public short CountRooms { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public short NumberApartment { get; init; }
        public string NumberProperty { get; init; }
        public EnumConditionHouse? ConditionHouse { get; init; }
        public decimal LivingSpace { get; init; }
        public decimal TotalArea { get; init; }
        public decimal KitchenArea { get; init; }
        public short CountFloorsHouse { get; init; }
        public short LocatedFloorApartment { get; init; }
        public bool IsCorner { get; init; }
        public short CountBalcony { get; init; }
        public EnumMaterialHouse? MaterialHouse { get; init; }
        public string Description { get; init; }
        public int Price { get; init; }
        public EmployeeDetailResponse? Employee { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public EnumLocality Locality { get; init; }
        public DateTime DateTimePublished { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public bool IsActual { get; init; }
    }
}
