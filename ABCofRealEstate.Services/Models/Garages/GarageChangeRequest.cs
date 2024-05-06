namespace ABCofRealEstate.Services.Models.Garages
{
    public class GarageChangeRequest
    {
        public GarageChangeRequest(
            Guid id,
            string? district,
            string? street,
            string description,
            int price,
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            short garageCapacity,
            bool haveBasement,
            decimal latitude,
            decimal longitude,
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
            GarageCapacity = garageCapacity;
            HaveBasement = haveBasement;
            Latitude = latitude;
            Longitude = longitude;
            IsActual = isActual;
        }
        public GarageChangeRequest()
        {
            
        }
        public Guid Id { get; init; }
        public string? District { get; init; }
        public string? Street { get; init; }
        public string? Description { get; init; }
        public int Price { get; init; }
        public Guid? EmployeeId { get; init; }
        public EnumLocality Locality { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public short GarageCapacity { get; init; }
        public bool HaveBasement { get; init; }
        public decimal Latitude { get; init; }
        public decimal Longitude { get; init; }
        public bool IsActual { get; init; }
    }
}
