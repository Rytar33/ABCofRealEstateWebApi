using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Models.Houses
{
    public class HouseDetailResponse
    {
        public HouseDetailResponse(
            Guid id,
            short countRooms,
            string? district,
            string? street,
            string numberProperty,
            EnumConditionHouse? conditionHouse,
            decimal livingSpace,
            decimal totalArea,
            decimal kitchenArea,
            bool isCorner,
            short countFloorsHouse,
            short locatedFloorApartment,
            EnumMaterialHouse? materialHouse,
            string description,
            int price,
            EmployeeDetailResponse? employee,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal gardenSot,
            decimal area,
            decimal latitude,
            decimal longitude,
            bool isActual,
            DateTime dateTimePublished,
            string[] fullPathsImage)
        {
            Id = id;
            CountRooms = countRooms;
            District = district;
            Street = street;
            NumberProperty = numberProperty;
            ConditionHouse = conditionHouse;
            LivingSpace = livingSpace;
            TotalArea = totalArea;
            KitchenArea = kitchenArea;
            IsCorner = isCorner;
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            MaterialHouse = materialHouse;
            Description = description;
            Price = price;
            Employee = employee;
            TypeSale = typeSale;
            Locality = locality;
            GardenSot = gardenSot;
            Area = area;
            Latitude = latitude;
            Longitude = longitude;
            IsActual = isActual;
            DateTimePublished = dateTimePublished;
            FullPathsImage = fullPathsImage;
        }
        public string[] FullPathsImage { get; init; }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public EmployeeDetailResponse? Employee { get; init; }
        public short CountRooms { get; init; }
        public short LocatedFloorApartment { get; init; }
        public short CountFloorsHouse { get; init; }
        public bool IsCorner { get; init; }
        public EnumMaterialHouse? MaterialHouse { get; init; }
        public EnumConditionHouse? ConditionHouse { get; init; }
        public decimal LivingSpace { get; init; }
        public decimal TotalArea { get; init; }
        public decimal KitchenArea { get; init; }
        public decimal Area { get; init; }
        public decimal GardenSot { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public EnumLocality Locality { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public DateTime DateTimePublished { get; init; }
        public bool IsActual { get; init; }
        public string NumberProperty { get; init; }
    }
}
