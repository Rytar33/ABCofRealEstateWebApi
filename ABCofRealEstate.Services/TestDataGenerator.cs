using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.Services.Extensions;
using Bogus;

namespace ABCofRealEstate.Services
{
    public class TestDataGenerator
    {
        private Faker _faker = new Faker("ru");
        public async Task<Apartament> GetGenerationApartament()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            var apartament = new Apartament()
            {
                CountFloorsHouse = (short)_faker.Random.Number(4, 25),
                LocatedFloorApartament = (short)_faker.Random.Number(1, 4),
                ConditionHouse = _faker.PickRandom<EnumConditionHouse>(),
                CountBalcony = (short)_faker.Random.Number(2),
                CountRooms = (short)_faker.Random.Number(1, 4),
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                MaterialHouse = _faker.PickRandom<EnumMaterialHouse>(),
                NumberApartament = (short)_faker.Random.Number(1, 60),
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                TotalArea = _faker.Random.Double(25, 150),
                LivingSpace = _faker.Random.Double(10, 100),
                KitchenArea = _faker.Random.Double(0, 50),
                NumberProperty = _faker.Address.BuildingNumber(),
                IsActual = true,
                IsCorner = _faker.Random.Bool(),
                Locality = _faker.PickRandom<EnumLocality>(),
                EmployeeId = 
                employees.Data != null 
                && employees.Data!.Any() 
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee 
                : null
            };
            return apartament;
        }
        public async Task<Area> GetGenerationArea()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Area()
            {
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                IsActual = true,
                Locality = _faker.PickRandom<EnumLocality>(),
                LandArea = _faker.Random.Number(50, 1000),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public async Task<Commertion> GetGenerationCommertion()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Commertion()
            {
                CountFloorsHouse = (short)_faker.Random.Number(4, 25),
                LocatedFloorApartament = (short)_faker.Random.Number(1, 4),
                CountRooms = (short)_faker.Random.Number(1, 4),
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                MaterialHouse = _faker.PickRandom<EnumMaterialHouse>(),
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                NumberProperty = _faker.Address.BuildingNumber(),
                IsActual = true,
                IsCorner = _faker.Random.Bool(),
                Locality = _faker.PickRandom<EnumLocality>(),
                RoomArea = _faker.Random.Double(30, 500),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public async Task<Garage> GetGenerationGarage()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Garage()
            {
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                IsActual = true,
                Locality = _faker.PickRandom<EnumLocality>(),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public async Task<Hostel> GetGenerationHostel()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Hostel()
            {
                CountFloorsHouse = (short)_faker.Random.Number(4, 25),
                LocatedFloorApartament = (short)_faker.Random.Number(1, 4),
                ConditionHouse = _faker.PickRandom<EnumConditionHouse>(),
                CountBalcony = (short)_faker.Random.Number(2),
                CountRooms = (short)_faker.Random.Number(1, 4),
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                MaterialHouse = _faker.PickRandom<EnumMaterialHouse>(),
                NumberApartament = (short)_faker.Random.Number(1, 60),
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                TotalArea = _faker.Random.Double(25, 150),
                LivingSpace = _faker.Random.Double(10, 100),
                KitchenArea = _faker.Random.Double(0, 50),
                NumberProperty = _faker.Address.BuildingNumber(),
                IsActual = true,
                IsCorner = _faker.Random.Bool(),
                Locality = _faker.PickRandom<EnumLocality>(),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public async Task<Room> GetGenerationHouse()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Room()
            {
                CountFloorsHouse = (short)_faker.Random.Number(4, 25),
                LocatedFloorApartament = (short)_faker.Random.Number(1, 4),
                ConditionHouse = _faker.PickRandom<EnumConditionHouse>(),
                CountBalcony = (short)_faker.Random.Number(2),
                CountRooms = (short)_faker.Random.Number(1, 4),
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                MaterialHouse = _faker.PickRandom<EnumMaterialHouse>(),
                NumberApartament = (short)_faker.Random.Number(1, 60),
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                TotalArea = _faker.Random.Double(25, 150),
                LivingSpace = _faker.Random.Double(10, 100),
                KitchenArea = _faker.Random.Double(0, 50),
                NumberProperty = _faker.Address.BuildingNumber(),
                IsActual = true,
                IsCorner = _faker.Random.Bool(),
                Locality = _faker.PickRandom<EnumLocality>(),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public async Task<Room> GetGenerationRoom()
        {
            var employees = await new EmployeeService().GetAllEmployees();
            return new Room()
            {
                CountFloorsHouse = (short)_faker.Random.Number(4, 25),
                LocatedFloorApartament = (short)_faker.Random.Number(1, 4),
                ConditionHouse = _faker.PickRandom<EnumConditionHouse>(),
                CountBalcony = (short)_faker.Random.Number(2),
                CountRooms = (short)_faker.Random.Number(1, 4),
                Price = _faker.Random.Number(50000, 500000),
                DateTimePublished = DateTime.Now,
                District = _faker.Address.State(),
                Street = _faker.Address.StreetName(),
                Description = "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                MaterialHouse = _faker.PickRandom<EnumMaterialHouse>(),
                NumberApartament = (short)_faker.Random.Number(1, 60),
                TypeSale = _faker.PickRandom<EnumTypeSale>(),
                TotalArea = _faker.Random.Double(25, 150),
                LivingSpace = _faker.Random.Double(10, 100),
                KitchenArea = _faker.Random.Double(0, 50),
                NumberProperty = _faker.Address.BuildingNumber(),
                IsActual = true,
                IsCorner = _faker.Random.Bool(),
                Locality = _faker.PickRandom<EnumLocality>(),
                EmployeeId =
                employees.Data != null
                && employees.Data!.Any()
                ? employees.Data![_faker.Random.Number(employees.Data!.Count - 1)].IdEmployee
                : null
            };
        }
        public Employee GetGenerationEmployee()
            => new Employee()
            {
                FullName = _faker.Person.FullName,
                Email = _faker.Person.Email,
                JobTitle = _faker.PickRandom<EnumJobTitleEmployee>(),
                NumberPhone = _faker.Random.ReplaceNumbers("####-####-###")
            };
        public Moderator GetGenerationModerator()
            => new Moderator()
            {
                Name = _faker.Name.FirstName(),
                Email = _faker.Person.Email,
                Password = "qwerty123".GetSha256(),
                AccessLevel = _faker.PickRandom<EnumAccessLevel>(),
                IsSuperModerator = _faker.Random.Bool()
            };
        
    }
}
