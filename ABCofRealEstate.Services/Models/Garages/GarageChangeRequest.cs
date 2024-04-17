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
            EnumLocality locality)
        {
            Id = id;
            District = district;
            Street = street;
            Description = description;
            Price = price;
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
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
        public bool IsActual { get; init; }
    }
}
