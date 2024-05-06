 using ABCofRealEstate.Services.Extensions;
using Bogus;

namespace ABCofRealEstate.Services
{
    public class TestDataGenerator : ITestDataGenerator
    {
        private readonly Faker _faker = new("ru");

        private static async Task<Employee?> GetFirstEmployee()
        {
            await using var db = new RealEstateDataContext();
            return await db.Employee.FirstOrDefaultAsync();
        }
        public async Task<Apartment> GetGenerationApartment()
        {
            var employee = await GetFirstEmployee();
            return new Apartment(
                _faker.Random.Short(1, 4),
                _faker.Address.State(),
                _faker.Address.StreetName(),
                _faker.Random.Short(1, 60),
                _faker.Address.BuildingNumber(),
                _faker.PickRandom<EnumConditionHouse>(),
                _faker.Random.Decimal(10, 100),
                _faker.Random.Decimal(25, 150),
                _faker.Random.Decimal(0, 50),
                _faker.Random.Short(4, 25),
                _faker.Random.Short(1, 4),
                _faker.Random.Bool(),
                _faker.Random.Short(2),
                _faker.PickRandom<EnumMaterialHouse>(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<Area> GetGenerationArea()
        {
            var employee = await GetFirstEmployee();
            return new Area(
                _faker.Address.State(),
                _faker.Address.StreetName(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Number(50, 1000),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<Comertion> GetGenerationComertion()
        {
            var employee = await GetFirstEmployee();
            return new Comertion(
                _faker.Random.Short(1, 4),
                _faker.Address.State(),
                _faker.Address.StreetName(),
                _faker.Address.BuildingNumber(),
                _faker.Random.Short(4, 25),
                _faker.Random.Short(1, 4),
                _faker.PickRandom<EnumMaterialHouse>(),
                _faker.Random.Decimal(30, 500),
                _faker.Random.Bool(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<Garage> GetGenerationGarage()
        {
            var employee = await GetFirstEmployee();
            return new Garage(
                _faker.Address.State(),
                _faker.Address.StreetName(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Short(1, 4),
                _faker.Random.Bool(),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<Hostel> GetGenerationHostel()
        {
            var employee = await GetFirstEmployee();
            return new Hostel(
                _faker.Random.Short(1, 4),
                _faker.Address.State(),
                _faker.Address.StreetName(),
                _faker.Random.Short(1, 60),
                _faker.Address.BuildingNumber(),
                _faker.PickRandom<EnumConditionHouse>(),
                _faker.Random.Decimal(10, 100),
                _faker.Random.Decimal(25, 150),
                _faker.Random.Decimal(0, 50),
                _faker.Random.Bool(),
                _faker.Random.Short(4, 25),
                _faker.Random.Short(1, 4),
                _faker.Random.Short(2),
                _faker.PickRandom<EnumMaterialHouse>(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<House> GetGenerationHouse()
        {
            var employee = await GetFirstEmployee();
            return new House(
                _faker.Random.Short(1, 4),
                _faker.Address.State(),
                _faker.Address.StreetName(),
                _faker.Address.BuildingNumber(),
                _faker.PickRandom<EnumConditionHouse>(),
                _faker.Random.Decimal(10, 100),
                _faker.Random.Decimal(25, 150),
                _faker.Random.Decimal(0, 50),
                _faker.Random.Short(1, 3),
                1,
                _faker.Random.Bool(),
                _faker.PickRandom<EnumMaterialHouse>(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Decimal(10, 150),
                _faker.Random.Decimal(100, 2000),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public async Task<Room> GetGenerationRoom()
        {
            var employee = await GetFirstEmployee();
            return new Room(
                _faker.Random.Short(1, 4),
                _faker.Address.State(),
                _faker.Address.StreetName(),
                _faker.Random.Short(1, 60),
                _faker.Address.BuildingNumber(),
                _faker.PickRandom<EnumConditionHouse>(),
                _faker.Random.Decimal(10, 100),
                _faker.Random.Decimal(25, 150),
                _faker.Random.Decimal(0, 50),
                _faker.Random.Bool(),
                _faker.Random.Short(4, 25),
                _faker.Random.Short(1, 4),
                _faker.Random.Short(2),
                _faker.PickRandom<EnumMaterialHouse>(),
                "lorem ispum dorem viktorian selem fszxc twerw fsfas qeee 12 333 fsdf.",
                _faker.Random.Number(50000, 500000),
                employee?.Id,
                _faker.PickRandom<EnumTypeSale>(),
                _faker.PickRandom<EnumLocality>(),
                _faker.Random.Decimal(-50, 50),
                _faker.Random.Decimal(-50, 50));
        }
        public Employee GetGenerationEmployee()
            => new(
                _faker.Person.Email,
                _faker.Person.FullName,
                _faker.PickRandom<EnumJobTitleEmployee>(),
                _faker.Random.ReplaceNumbers("+373 ### ### ##"));
        public Moderator GetGenerationModerator()
            => new(
                _faker.Name.FirstName(),
                _faker.Person.Email,
                "qwerty123".GetSha256())
            {
                IsSuperModerator = _faker.Random.Bool()
            };
        
    }
}
