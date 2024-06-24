using ABCofRealEstate.Services.Interfaces.Services;
using ABCofRealEstate.Services.Models.Apartments;

namespace ABCofRealEstate.Service.Tests
{
    public class ApartmentServiceTests
    {
        private async Task<ApartmentCreateRequest> GetApartmentCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var apartment = await testDataGenerator.GetGenerationApartment();
            return new ApartmentCreateRequest(
                apartment.CountRooms,
                apartment.District,
                apartment.Street,
                apartment.NumberApartment,
                apartment.NumberProperty,
                apartment.ConditionHouse,
                apartment.LivingSpace,
                apartment.TotalArea,
                apartment.KitchenArea,
                apartment.IsCorner,
                apartment.CountFloorsHouse,
                apartment.LocatedFloorApartment,
                apartment.CountBalcony,
                apartment.MaterialHouse,
                apartment.Description,
                apartment.Price,
                apartment.EmployeeId,
                apartment.TypeSale,
                apartment.Locality,
                apartment.Latitude,
                apartment.Longitude,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetApartmentFromServiceTest()
        {
            //Arrange
            IApartmentService apartmentService = new ApartmentService();
            var apartmentCreateRequest = await GetApartmentCreateRequest();
            var responseCreated = await apartmentService.Create(apartmentCreateRequest);

            //Act
            var responseGet = await apartmentService.Get(responseCreated.Data!.Id);

            //Assert
            Assert.True(responseGet.IsSuccess);
            await apartmentService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddApartmentInServiceTest()
        {
            //Arrange
            IApartmentService apartmentService = new ApartmentService();
            var apartmentCreateRequest = await GetApartmentCreateRequest();

            //Act
            var response = await apartmentService.Create(apartmentCreateRequest);

            //Assert
            Assert.NotNull(response.Data);
            await apartmentService.Delete(response.Data!.Id);
        }
        [Fact]
        public async Task UpdateApartmentInServiceTest()
        {
            //Arrange
            IApartmentService apartmentService = new ApartmentService();
            var apartmentCreateRequest = await GetApartmentCreateRequest();
            var responseCreated = await apartmentService.Create(apartmentCreateRequest);
            var apartmentChangeRequest = new ApartmentChangeRequest(
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
                responseCreated.Data!.CountFloorsHouse,
                responseCreated.Data!.LocatedFloorApartment,
                responseCreated.Data!.IsCorner,
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

            //Act
            var responseChanged = await apartmentService.Change(apartmentChangeRequest);

            //Assert
            Assert.Equal(apartmentChangeRequest.Price, responseChanged.Data!.Price);
            await apartmentService.Delete(responseChanged.Data!.Id);
        }
        [Fact]
        public async Task DeleteApartmentFromServiceTest()
        {
            //Arrange
            IApartmentService apartmentService = new ApartmentService();
            var apartmentCreateRequest = await GetApartmentCreateRequest();
            var responseCreated = await apartmentService.Create(apartmentCreateRequest);
            
            //Act
            var responseDeleted = await apartmentService.Delete(responseCreated.Data!.Id);

            //Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}