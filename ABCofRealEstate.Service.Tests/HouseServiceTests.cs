using ABCofRealEstate.Services.Interfaces.Services;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Service.Tests
{
    public class HouseServiceTests
    {
        private async Task<HouseCreateRequest> GetHouseCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var house = await testDataGenerator.GetGenerationHouse();
            return new HouseCreateRequest(
                house.CountRooms,
                house.District,
                house.Street,
                house.NumberProperty,
                house.ConditionHouse,
                house.LivingSpace,
                house.TotalArea,
                house.KitchenArea,
                house.IsCorner,
                house.CountFloorsHouse,
                house.LocatedFloorApartment,
                house.MaterialHouse,
                house.Description,
                house.Price,
                house.EmployeeId,
                house.TypeSale,
                house.Locality,
                house.GardenSot,
                house.Area,
                house.Latitude,
                house.Longitude,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetHouseFromServiceTest()
        {
            // Arrange
            IHouseService houseService = new HouseService();
            var houseCreateRequest = await GetHouseCreateRequest();
            var responseCreated = await houseService.Create(houseCreateRequest);
            
            // Act
            var responseGet = await houseService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess & responseGet.Data != null);
            await houseService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddHouseInServiceTest()
        {
            // Arrange
            IHouseService houseService = new HouseService();
            var houseCreateRequest = await GetHouseCreateRequest();
            
            // Act
            var responseCreated = await houseService.Create(houseCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess & responseCreated.Data != null);
            await houseService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateHouseInServiceTest()
        {
            // Arrange
            IHouseService houseService = new HouseService();
            var houseCreateRequest = await GetHouseCreateRequest();
            var responseCreated = await houseService.Create(houseCreateRequest);
            var houseChangeRequest = new HouseChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.CountRooms,
                responseCreated.Data!.District,
                responseCreated.Data!.Street,
                responseCreated.Data!.NumberProperty,
                responseCreated.Data!.ConditionHouse,
                responseCreated.Data!.LivingSpace,
                responseCreated.Data!.TotalArea,
                responseCreated.Data!.KitchenArea,
                responseCreated.Data!.IsCorner,
                responseCreated.Data!.CountFloorsHouse,
                responseCreated.Data!.LocatedFloorApartment,
                responseCreated.Data!.MaterialHouse,
                responseCreated.Data!.Description,
                11111,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality,
                responseCreated.Data!.GardenSot,
                responseCreated.Data!.Area,
                responseCreated.Data!.Latitude,
                responseCreated.Data!.Longitude,
                responseCreated.Data!.IsActual);
            
            // Act
            var responseChanged = await houseService.Change(houseChangeRequest);

            // Assert
            Assert.True(responseChanged.IsSuccess 
                        && responseChanged.Data != null
                        && responseChanged.Data.IsActual == houseChangeRequest.IsActual);
            await houseService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task DeleteHouseFromServiceTest()
        {
            // Arrange
            IHouseService houseService = new HouseService();
            var houseCreateRequest = await GetHouseCreateRequest();
            var responseCreated = await houseService.Create(houseCreateRequest);
            
            // Act
            var responseDeleted = await houseService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
