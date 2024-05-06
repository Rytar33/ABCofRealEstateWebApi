using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Service.Tests
{
    public class HostelServiceTests
    {
        private async Task<HostelCreateRequest> GetHostelCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var hostel = await testDataGenerator.GetGenerationHostel();
            return new HostelCreateRequest(
                hostel.CountRooms,
                hostel.District,
                hostel.Street,
                hostel.NumberApartment,
                hostel.NumberProperty,
                hostel.ConditionHouse,
                hostel.LivingSpace,
                hostel.TotalArea,
                hostel.KitchenArea,
                hostel.IsCorner,
                hostel.CountFloorsHouse,
                hostel.LocatedFloorApartment,
                hostel.CountBalcony,
                hostel.MaterialHouse,
                hostel.Description,
                hostel.Price,
                hostel.EmployeeId,
                hostel.TypeSale,
                hostel.Locality,
                hostel.Latitude,
                hostel.Longitude,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetHostelFromServiceTest()
        {
            // Arrange
            IHostelService hostelService = new HostelService();
            var hostelCreateRequest = await GetHostelCreateRequest();
            var responseCreated = await hostelService.Create(hostelCreateRequest);

            // Act
            var responseGet = await hostelService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess && responseGet.Data != null);
            await hostelService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddHostelInServiceTest()
        {
            // Arrange
            IHostelService hostelService = new HostelService();
            var hostelCreateRequest = await GetHostelCreateRequest();

            // Act
            var responseCreated = await hostelService.Create(hostelCreateRequest);
            if (responseCreated.IsSuccess == false)
                Assert.Fail(responseCreated.ErrorMessage);
            // Assert
            Assert.True(responseCreated.IsSuccess && responseCreated.Data != null);
            await hostelService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateHostelInServiceTest()
        {
            // Arrange
            IHostelService hostelService = new HostelService();
            var hostelCreateRequest = await GetHostelCreateRequest();
            var responseCreated = await hostelService.Create(hostelCreateRequest);
            var hostelChangeRequest = new HostelChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.CountRooms,
                responseCreated.Data!.District,
                responseCreated.Data!.Street,
                responseCreated.Data!.NumberApartment,
                responseCreated.Data!.NumberProperty,
                responseCreated.Data!.ConditionHouse,
                responseCreated.Data!.LivingSpace,
                responseCreated.Data!.TotalArea,
                responseCreated.Data!.KitchenArea,
                responseCreated.Data!.IsCorner,
                responseCreated.Data!.CountFloorsHouse,
                responseCreated.Data!.LocatedFloorApartment,
                responseCreated.Data!.CountBalcony,
                responseCreated.Data!.MaterialHouse,
                responseCreated.Data!.Description,
                11111,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality,
                responseCreated.Data!.Latitude,
                responseCreated.Data!.Longitude,
                responseCreated.Data!.IsActual);

            // Act
            var responseChanged = await hostelService.Change(hostelChangeRequest);

            // Assert
            Assert.True(responseChanged.IsSuccess
                && responseChanged.Data != null
                && responseChanged.Data.Price == hostelChangeRequest.Price);
            await hostelService.Delete(responseChanged.Data!.Id);
        }
        [Fact]
        public async Task DeleteHostelFromServiceTest()
        {
            // Arrange
            IHostelService hostelService = new HostelService();
            var hostelCreateRequest = await GetHostelCreateRequest();
            var responseCreated = await hostelService.Create(hostelCreateRequest);

            // Act
            var responseDeleted = await hostelService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
