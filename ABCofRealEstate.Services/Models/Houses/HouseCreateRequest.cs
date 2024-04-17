using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Houses
{
    public class HouseCreateRequest
    {
        public HouseCreateRequest(
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
            Guid? employeeId,
            EnumTypeSale typeSale,
            EnumLocality locality,
            decimal gardenSot,
            decimal area,
            ICollection<IFormFile> files)
        {
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
            EmployeeId = employeeId;
            TypeSale = typeSale;
            Locality = locality;
            GardenSot = gardenSot;
            Area = area;
            Files = files;
        }
        public HouseCreateRequest()
        {
            
        }
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
        public EnumConditionHouse? ConditionHouse { get; init; }
        public decimal LivingSpace { get; init; }
        public decimal TotalArea { get; init; }
        public decimal KitchenArea { get; init; }
        public decimal Area { get; init; }
        public decimal GardenSot { get; init; }
        public EnumTypeSale TypeSale { get; init; }
        public EnumLocality Locality { get; init; }
        public string NumberProperty { get; init; }
        public ICollection<IFormFile> Files { get; init; }
    }
}
