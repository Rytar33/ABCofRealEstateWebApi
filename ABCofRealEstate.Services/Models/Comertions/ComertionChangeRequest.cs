namespace ABCofRealEstate.Services.Models.Comertions
{
    public class ComertionChangeRequest
    {
        public ComertionChangeRequest(
            Guid id,
            short countRooms,
            string? district,
            string? street,
            string numberProperty,
            short countFloorsHouse,
            short locatedFloorApartment,
            EnumMaterialHouse? materialHouse,
            bool isCorner,
            string description,
            int price,
            Guid? employeeId,
            decimal roomArea,
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
            CountFloorsHouse = countFloorsHouse;
            LocatedFloorApartment = locatedFloorApartment;
            MaterialHouse = materialHouse;
            IsCorner = isCorner;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            RoomArea = roomArea;
            TypeSale = typeSale;
            Locality = locality;
            Latitude = latitude;
            Longitude = longitude;
            IsActual = isActual;
        }
        public ComertionChangeRequest()
        {
            
        }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public Guid? EmployeeId { get; init; }
        public short CountRooms { get; init; }
        public short LocatedFloorApartment { get; init; }
        public short CountFloorsHouse { get; init; }
        public bool IsCorner { get; init; }
        public EnumMaterialHouse? MaterialHouse { get; init; }
        public decimal RoomArea { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public EnumLocality Locality { get; init; }
        public string NumberProperty { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public bool IsActual { get; init; }
    }
}
