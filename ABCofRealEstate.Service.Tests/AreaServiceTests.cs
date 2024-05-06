using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.Service.Tests
{
    public class AreaServiceTests
    {
        private async Task<AreaCreateRequest> GetAreaCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var area = await testDataGenerator.GetGenerationArea();
            return new AreaCreateRequest(
                area.District,
                area.Street,
                area.Description,
                area.Price,
                area.EmployeeId,
                area.TypeSale,
                area.Locality,
                area.LandArea,
                area.Latitude,
                area.Longitude,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetAreaFromServiceTest()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            var areaCreateRequest = await GetAreaCreateRequest();
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Act
            var responseGet = await areaService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess);
            if (responseCreated.IsSuccess)
                await areaService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task AddAreaInServiceTest()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            var areaCreateRequest = await GetAreaCreateRequest();

            // Act
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess);
            //if (responseCreated.IsSuccess)
             await areaService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateAreaInServiceTest()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            var areaCreateRequest = await GetAreaCreateRequest();
            var responseCreated = await areaService.Create(areaCreateRequest);
            var areaChangeRequest = new AreaChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.District,
                responseCreated.Data!.Street,
                responseCreated.Data!.Description,
                11111,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality,
                responseCreated.Data!.LandArea,
                responseCreated.Data!.Latitude,
                responseCreated.Data!.Longitude,
                responseCreated.Data!.IsActual);

            // Act
            var responseUpdated = await areaService.Change(areaChangeRequest);

            // Assert
            Assert.Equal(areaChangeRequest.Price, responseUpdated.Data!.Price);
            if (responseUpdated.IsSuccess)
                await areaService.Delete(responseUpdated.Data!.Id);
        }
        [Fact]
        public async Task DeleteAreaFromServiceTest()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            var areaCreateRequest = await GetAreaCreateRequest();
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Act
            var responseDelete = await areaService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDelete.IsSuccess);
        }
    }
}
