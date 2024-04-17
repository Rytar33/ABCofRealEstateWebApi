using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Service.Tests
{
    public class RoomServiceTests
    {
        private async Task<RoomCreateRequest> GetRoomCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var room = await testDataGenerator.GetGenerationRoom();
            return new RoomCreateRequest(
                room.CountRooms,
                room.District,
                room.Street,
                room.NumberApartment,
                room.NumberProperty,
                room.ConditionHouse,
                room.LivingSpace,
                room.TotalArea,
                room.KitchenArea,
                room.IsCorner,
                room.CountFloorsHouse,
                room.LocatedFloorApartment,
                room.CountBalcony,
                room.MaterialHouse,
                room.Description,
                room.Price,
                room.EmployeeId,
                room.TypeSale,
                room.Locality,
                new List<IFormFile>());
        }
        [Fact]
        public async Task GetRoomFromServiceTest()
        {
            // Arrange
            IRoomService roomService = new RoomService();
            var roomCreateRequest = await GetRoomCreateRequest();
            var responseCreated = await roomService.Create(roomCreateRequest);
            
            // Act
            var responseGet = await roomService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess & responseGet.Data != null);
            await roomService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddRoomInServiceTest()
        {
            // Arrange
            IRoomService roomService = new RoomService();
            var roomCreateRequest = await GetRoomCreateRequest();
            
            // Act
            var responseCreated = await roomService.Create(roomCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess & responseCreated.Data != null);
            await roomService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateRoomInServiceTest()
        {
            // Arrange
            IRoomService roomService = new RoomService();
            var roomCreateRequest = await GetRoomCreateRequest();
            var responseCreated = await roomService.Create(roomCreateRequest);
            var roomChangeRequest = new RoomChangeRequest(
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
                responseCreated.Data!.Price,
                responseCreated.Data!.Employee?.Id,
                responseCreated.Data!.TypeSale,
                responseCreated.Data!.Locality,
                false);
            
            // Act
            var responseChanged = await roomService.Change(roomChangeRequest);

            // Assert
            Assert.True(responseChanged.IsSuccess 
                        & responseChanged.Data != null
                        && responseChanged.Data.IsActual == roomChangeRequest.IsActual);
            await roomService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task DeleteRoomFromServiceTest()
        {
            // Arrange
            IRoomService roomService = new RoomService();
            var roomCreateRequest = await GetRoomCreateRequest();
            var responseCreated = await roomService.Create(roomCreateRequest);
            
            // Act
            var responseDeleted = await roomService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
