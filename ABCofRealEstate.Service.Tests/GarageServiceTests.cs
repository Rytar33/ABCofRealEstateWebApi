using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Service.Tests
{
    public class GarageServiceTests
    {
        private async Task<GarageCreateRequest> GetGarageCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var garage = await testDataGenerator.GetGenerationGarage();
            return new GarageCreateRequest(
                garage.District,
                garage.Street,
                garage.Description,
                garage.Price,
                garage.EmployeeId,
                garage.TypeSale,
                garage.Locality,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetGarageFromServiceTest()
        {
            // Arrange
            IGarageService garageService = new GarageService();
            var garageCreateRequest = await GetGarageCreateRequest();
            var responseCreated = await garageService.Create(garageCreateRequest);
            
            // Act
            var responseGet = await garageService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess & responseGet.Data != null);
            await garageService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddGarageInServiceTest()
        {
            // Arrange
            IGarageService garageService = new GarageService();
            var garageCreateRequest = await GetGarageCreateRequest();
            
            // Act
            var responseCreated = await garageService.Create(garageCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess & responseCreated.Data != null);
            await garageService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateGarageInServiceTest()
        {
            // Arrange
            IGarageService garageService = new GarageService();
            var garageCreateRequest = await GetGarageCreateRequest();
            var responseCreated = await garageService.Create(garageCreateRequest);
            var garageChangeRequest = new GarageChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.District,
                responseCreated.Data!.Street,
                responseCreated.Data!.Description,
                responseCreated.Data!.Price,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality)
            {
                Id = responseCreated.Data!.Id,
                District = responseCreated.Data!.District,
                Street = responseCreated.Data!.Street,
                Description = responseCreated.Data!.Description,
                Price = responseCreated.Data!.Price,
                EmployeeId = responseCreated.Data!.Employee?.Id,
                Locality = responseCreated.Data!.Locality,
                TypeSale = responseCreated.Data!.TypeSale,
                IsActual = false
            };
            // Act
            var responseChanged = await garageService.Change(garageChangeRequest);

            // Assert
            Assert.True(responseChanged.IsSuccess 
                        && responseChanged.Data != null
                        && responseChanged.Data.IsActual == garageChangeRequest.IsActual);
            await garageService.Delete(responseChanged.Data!.Id);
        }
        [Fact]
        public async Task DeleteGarageFromServiceTest()
        {
            // Arrange
            IGarageService garageService = new GarageService();
            var garageCreateRequest = await GetGarageCreateRequest();
            var responseCreated = await garageService.Create(garageCreateRequest);
            
            // Act
            var responseDeleted = await garageService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
            
        }
    }
}
