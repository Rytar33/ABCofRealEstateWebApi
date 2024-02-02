using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.Service.Tests
{
    public class CommertionServiceTests
    {
        [Fact]
        public async Task GetCommertionFromServiceTest()
        {
            // Arrange
            var commertionService = new CommertionService();
            var generatedCommertion = await new TestDataGenerator().GetGenerationCommertion();
            var commertionCreateRequest = new CommertionCreateRequest()
            {
                Price = generatedCommertion.Price,
                CountFloorsHouse = generatedCommertion.CountFloorsHouse,
                LocatedFloorApartament = generatedCommertion.LocatedFloorApartament,
                CountRooms = generatedCommertion.CountRooms,
                Description = generatedCommertion.Description,
                District = generatedCommertion.District,
                IdEmployee = generatedCommertion.EmployeeId,
                IsCorner = generatedCommertion.IsCorner,
                Locality = generatedCommertion.Locality,
                MaterialHouse = generatedCommertion.MaterialHouse,
                NumberProperty = generatedCommertion.NumberProperty,
                RoomArea = generatedCommertion.RoomArea,
                TypeSale = generatedCommertion.TypeSale,
                Street = generatedCommertion.Street
            };
            var responseCreated = await commertionService.Create(commertionCreateRequest);

            // Act
            var responseGet = await commertionService.Get(responseCreated.Data!.IdCommertion);

            // Assert
            Assert.True(responseGet.Data != null && responseGet.IsSuccses);
            await commertionService.Delete(responseGet.Data!.IdCommertion);
        }
        [Fact]
        public async Task AddCommertionInServiceTest()
        {
            // Arrange
            var commertionService = new CommertionService();
            var generatedCommertion = await new TestDataGenerator().GetGenerationCommertion();
            var commertionCreateRequest = new CommertionCreateRequest()
            {
                Price = generatedCommertion.Price,
                CountFloorsHouse = generatedCommertion.CountFloorsHouse,
                LocatedFloorApartament = generatedCommertion.LocatedFloorApartament,
                CountRooms = generatedCommertion.CountRooms,
                Description = generatedCommertion.Description,
                District = generatedCommertion.District,
                IdEmployee = generatedCommertion.EmployeeId,
                IsCorner = generatedCommertion.IsCorner,
                Locality = generatedCommertion.Locality,
                MaterialHouse = generatedCommertion.MaterialHouse,
                NumberProperty = generatedCommertion.NumberProperty,
                RoomArea = generatedCommertion.RoomArea,
                TypeSale = generatedCommertion.TypeSale,
                Street = generatedCommertion.Street
            };

            // Act
            var responseCreated = await commertionService.Create(commertionCreateRequest);

            // Assert
            Assert.True(responseCreated.Data != null && responseCreated.IsSuccses);
            await commertionService.Delete(responseCreated.Data!.IdCommertion);
        }
        [Fact]
        public async Task UpdateCommertionInServiceTest()
        {
            // Arrange
            var commertionService = new CommertionService();
            var generatedCommertion = await new TestDataGenerator().GetGenerationCommertion();
            var commertionCreateRequest = new CommertionCreateRequest()
            {
                Price = generatedCommertion.Price,
                CountFloorsHouse = generatedCommertion.CountFloorsHouse,
                LocatedFloorApartament = generatedCommertion.LocatedFloorApartament,
                CountRooms = generatedCommertion.CountRooms,
                Description = generatedCommertion.Description,
                District = generatedCommertion.District,
                IdEmployee = generatedCommertion.EmployeeId,
                IsCorner = generatedCommertion.IsCorner,
                Locality = generatedCommertion.Locality,
                MaterialHouse = generatedCommertion.MaterialHouse,
                NumberProperty = generatedCommertion.NumberProperty,
                RoomArea = generatedCommertion.RoomArea,
                TypeSale = generatedCommertion.TypeSale,
                Street = generatedCommertion.Street
            };
            var responseCreated = await commertionService.Create(commertionCreateRequest);
            var commertionUpdateRequest = new CommertionChangeRequest()
            {
                IdCommertion = responseCreated.Data!.IdCommertion,
                CountFloorsHouse = responseCreated.Data!.CountFloorsHouse,
                LocatedFloorApartament = responseCreated.Data!.LocatedFloorApartament,
                CountRooms = responseCreated.Data!.CountRooms,
                Description = responseCreated.Data!.Description,
                Price = 11111,
                RoomArea = responseCreated.Data!.RoomArea,
                District = responseCreated.Data!.District,
                IdEmployee = responseCreated.Data.Employee is not null 
                ? responseCreated.Data!.Employee.IdEmployee
                : null,
                IsActual = responseCreated.Data!.IsActual,
                IsCorner = responseCreated.Data!.IsCorner,
                Locality = responseCreated.Data!.Locality,
                MaterialHouse = responseCreated.Data!.MaterialHouse,
                NumberProperty = responseCreated.Data!.NumberProperty,
                Street = responseCreated.Data!.Street,
                TypeSale = responseCreated.Data!.TypeSale
            };

            // Act
            var responseUpdate = await commertionService.Change(commertionUpdateRequest);

            // Assert
            Assert.True(responseUpdate.Data != null 
                && responseUpdate.IsSuccses 
                && responseUpdate.Data.Price == commertionUpdateRequest.Price);
            await commertionService.Delete(responseUpdate.Data!.IdCommertion);
        }
        [Fact]
        public async Task DeleteCommertionFromServiceTest()
        {
            // Arrange
            var commertionService = new CommertionService();
            var generatedCommertion = await new TestDataGenerator().GetGenerationCommertion();
            var commertionCreateRequest = new CommertionCreateRequest()
            {
                Price = generatedCommertion.Price,
                CountFloorsHouse = generatedCommertion.CountFloorsHouse,
                LocatedFloorApartament = generatedCommertion.LocatedFloorApartament,
                CountRooms = generatedCommertion.CountRooms,
                Description = generatedCommertion.Description,
                District = generatedCommertion.District,
                IdEmployee = generatedCommertion.EmployeeId,
                IsCorner = generatedCommertion.IsCorner,
                Locality = generatedCommertion.Locality,
                MaterialHouse = generatedCommertion.MaterialHouse,
                NumberProperty = generatedCommertion.NumberProperty,
                RoomArea = generatedCommertion.RoomArea,
                TypeSale = generatedCommertion.TypeSale,
                Street = generatedCommertion.Street
            };
            var responseCreated = await commertionService.Create(commertionCreateRequest);

            // Act
            var responseDeleted = await commertionService.Delete(responseCreated.Data!.IdCommertion);

            // Assert
            Assert.True(responseDeleted.IsSuccses);
        }
    }
}
