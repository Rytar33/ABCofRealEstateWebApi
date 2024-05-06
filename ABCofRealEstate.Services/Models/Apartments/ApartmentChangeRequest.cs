namespace ABCofRealEstate.Services.Models.Apartments
{
    public class ApartmentChangeRequest
    {
        public ApartmentChangeRequest(
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
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal latitude,
            decimal longitude,
            bool isActual)
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
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            Latitude = latitude;
            Longitude = longitude;
            IsActual = isActual;
        }
        public ApartmentChangeRequest()
        {
            
        }
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
        public Guid? EmployeeId { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public EnumLocality Locality { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public bool IsActual { get; init; }
    }
}
