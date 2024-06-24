using ABCofRealEstate.Services.Interfaces.Services;
using ABCofRealEstate.Services.Models.Comertions;

namespace ABCofRealEstate.Service.Tests
{
    public class ComertionServiceTests
    {
        private async Task<ComertionCreateRequest> GetComertionCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var comertion = await testDataGenerator.GetGenerationComertion();
            return new ComertionCreateRequest(
                comertion.CountRooms,
                comertion.District,
                comertion.Street,
                comertion.NumberProperty,
                comertion.CountFloorsHouse,
                comertion.LocatedFloorApartment,
                comertion.MaterialHouse,
                comertion.IsCorner,
                comertion.Description,
                comertion.Price,
                comertion.EmployeeId,
                comertion.RoomArea,
                comertion.TypeSale,
                comertion.Locality,
                comertion.Latitude,
                comertion.Longitude,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetCommertionFromServiceTest()
        {
            // Arrange
            IComertionService comertionService = new ComertionService();
            var comertionCreateRequest = await GetComertionCreateRequest();
            var responseCreated = await comertionService.Create(comertionCreateRequest);

            // Act
            var responseGet = await comertionService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.Data != null & responseGet.IsSuccess);
            await comertionService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddCommertionInServiceTest()
        {
            // Arrange
            IComertionService comertionService = new ComertionService();
            var comertionCreateRequest = await GetComertionCreateRequest();

            // Act
            var responseCreated = await comertionService.Create(comertionCreateRequest);

            // Assert
            Assert.True(responseCreated.Data != null && responseCreated.IsSuccess);
            await comertionService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateCommertionInServiceTest()
        {
            // Arrange
            IComertionService comertionService = new ComertionService();
            var comertionCreateRequest = await GetComertionCreateRequest();
            var responseCreated = await comertionService.Create(comertionCreateRequest);
            var commertionUpdateRequest = new ComertionChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.CountRooms,
                responseCreated.Data!.District,
                responseCreated.Data!.Street,
                responseCreated.Data!.NumberProperty,
                responseCreated.Data!.CountFloorsHouse,
                responseCreated.Data!.LocatedFloorApartment,
                responseCreated.Data!.MaterialHouse,
                responseCreated.Data!.IsCorner,
                responseCreated.Data!.Description,
                11111,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.RoomArea,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality,
                responseCreated.Data!.Latitude,
                responseCreated.Data!.Longitude,
                responseCreated.Data!.IsActual);

            // Act
            var responseUpdate = await comertionService.Change(commertionUpdateRequest);

            // Assert
            Assert.True(responseUpdate.Data != null 
                && responseUpdate.IsSuccess 
                && responseUpdate.Data.Price == commertionUpdateRequest.Price);
            await comertionService.Delete(responseUpdate.Data!.Id);
        }
        [Fact]
        public async Task DeleteCommertionFromServiceTest()
        {
            // Arrange
            IComertionService comertionService = new ComertionService();
            var comertionCreateRequest = await GetComertionCreateRequest();
            var responseCreated = await comertionService.Create(comertionCreateRequest);

            // Act
            var responseDeleted = await comertionService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
