using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Service.Tests
{
    public class HostelServiceTests
    {
        [Fact]
        public async Task GetHostelFromServiceTest()
        {
            // Arrange
            var hostelService = new HostelService();
            var hostel = await new TestDataGenerator().GetGenerationHostel();
            var hostelCreateRequest = new HostelCreateRequest()
            {
                CountFloorsHouse = hostel.CountFloorsHouse,
                LocatedFloorApartament = hostel.LocatedFloorApartament,
                ConditionHouse = hostel.ConditionHouse,
                CountBalcony = hostel.CountBalcony,
                CountRooms = hostel.CountRooms,
                Description = hostel.Description,
                District = hostel.District,
                IdEmployee = hostel.EmployeeId,
                IsCorner = hostel.IsCorner,
                KitchenArea = hostel.KitchenArea,
                LivingSpace = hostel.LivingSpace,
                Locality = hostel.Locality,
                MaterialHouse = hostel.MaterialHouse,
                NumberApartament = hostel.NumberApartament,
                NumberProperty = hostel.NumberProperty,
                Price = hostel.Price,
                Street = hostel.Street,
                TotalArea = hostel.TotalArea,
                TypeSale = hostel.TypeSale
            };
            var responseCreated = await hostelService.Create(hostelCreateRequest);

            // Act
            var responseGet = await hostelService.Get(responseCreated.Data!.IdHostel);

            // Assert
            Assert.True(responseGet.IsSuccses && responseGet.Data != null);
            await hostelService.Delete(responseGet.Data!.IdHostel);
        }
        [Fact]
        public async Task AddHostelInServiceTest()
        {
            // Arrange
            var hostelService = new HostelService();
            var hostel = await new TestDataGenerator().GetGenerationHostel();
            var hostelCreateRequest = new HostelCreateRequest()
            {
                CountFloorsHouse = hostel.CountFloorsHouse,
                LocatedFloorApartament = hostel.LocatedFloorApartament,
                ConditionHouse = hostel.ConditionHouse,
                CountBalcony = hostel.CountBalcony,
                CountRooms = hostel.CountRooms,
                Description = hostel.Description,
                District = hostel.District,
                IdEmployee = hostel.EmployeeId,
                IsCorner = hostel.IsCorner,
                KitchenArea = hostel.KitchenArea,
                LivingSpace = hostel.LivingSpace,
                Locality = hostel.Locality,
                MaterialHouse = hostel.MaterialHouse,
                NumberApartament = hostel.NumberApartament,
                NumberProperty = hostel.NumberProperty,
                Price = hostel.Price,
                Street = hostel.Street,
                TotalArea = hostel.TotalArea,
                TypeSale = hostel.TypeSale
            };

            // Act
            var responseCreated = await hostelService.Create(hostelCreateRequest);
            if (responseCreated.IsSuccses == false)
                Assert.Fail(responseCreated.ErrorMessage);
            // Assert
            Assert.True(responseCreated.IsSuccses && responseCreated.Data != null);
            await hostelService.Delete(responseCreated.Data!.IdHostel);
        }
        [Fact]
        public async Task UpdateHostelInServiceTest()
        {
            // Arrange
            var hostelService = new HostelService();
            var hostel = await new TestDataGenerator().GetGenerationHostel();
            var hostelCreateRequest = new HostelCreateRequest()
            {
                CountFloorsHouse = hostel.CountFloorsHouse,
                LocatedFloorApartament = hostel.LocatedFloorApartament,
                ConditionHouse = hostel.ConditionHouse,
                CountBalcony = hostel.CountBalcony,
                CountRooms = hostel.CountRooms,
                Description = hostel.Description,
                District = hostel.District,
                IdEmployee = hostel.EmployeeId,
                IsCorner = hostel.IsCorner,
                KitchenArea = hostel.KitchenArea,
                LivingSpace = hostel.LivingSpace,
                Locality = hostel.Locality,
                MaterialHouse = hostel.MaterialHouse,
                NumberApartament = hostel.NumberApartament,
                NumberProperty = hostel.NumberProperty,
                Price = hostel.Price,
                Street = hostel.Street,
                TotalArea = hostel.TotalArea,
                TypeSale = hostel.TypeSale
            };
            var responseCreated = await hostelService.Create(hostelCreateRequest);
            var hostelChangeRequest = new HostelChangeRequest() 
            {
                IdHostel = responseCreated.Data!.IdHostel,
                CountFloorsHouse = responseCreated.Data!.CountFloorsHouse,
                LocatedFloorApartament = responseCreated.Data!.LocatedFloorApartament,
                ConditionHouse = responseCreated.Data!.ConditionHouse,
                CountBalcony = responseCreated.Data!.CountBalcony,
                CountRooms = responseCreated.Data!.CountRooms,
                Description = responseCreated.Data!.Description,
                District = responseCreated.Data!.District,
                IdEmployee = responseCreated.Data!.Employee is not null
                ? responseCreated.Data!.Employee.IdEmployee 
                : null,
                IsActual = responseCreated.Data!.IsActual,
                IsCorner = responseCreated.Data!.IsCorner,
                KitchenArea = responseCreated.Data!.KitchenArea,
                LivingSpace = responseCreated.Data!.LivingSpace,
                Locality = responseCreated.Data!.Locality,
                MaterialHouse = responseCreated.Data!.MaterialHouse,
                NumberApartament = responseCreated.Data!.NumberApartament,
                NumberProperty = responseCreated.Data!.NumberProperty,
                Price = 11111,
                Street = responseCreated.Data!.Street,
                TotalArea = responseCreated.Data!.TotalArea,
                TypeSale = responseCreated.Data!.TypeSale
            };

            // Act
            var reposneUpdated = await hostelService.Change(hostelChangeRequest);

            // Assert
            Assert.True(reposneUpdated.IsSuccses
                && reposneUpdated.Data != null
                && reposneUpdated.Data.Price == hostelChangeRequest.Price);
            await hostelService.Delete(reposneUpdated.Data!.IdHostel);
        }
        [Fact]
        public async Task DeleteHostelFromServiceTest()
        {
            // Arrange
            var hostelService = new HostelService();
            var hostel = await new TestDataGenerator().GetGenerationHostel();
            var hostelCreateRequest = new HostelCreateRequest()
            {
                CountFloorsHouse = hostel.CountFloorsHouse,
                LocatedFloorApartament = hostel.LocatedFloorApartament,
                ConditionHouse = hostel.ConditionHouse,
                CountBalcony = hostel.CountBalcony,
                CountRooms = hostel.CountRooms,
                Description = hostel.Description,
                District = hostel.District,
                IdEmployee = hostel.EmployeeId,
                IsCorner = hostel.IsCorner,
                KitchenArea = hostel.KitchenArea,
                LivingSpace = hostel.LivingSpace,
                Locality = hostel.Locality,
                MaterialHouse = hostel.MaterialHouse,
                NumberApartament = hostel.NumberApartament,
                NumberProperty = hostel.NumberProperty,
                Price = hostel.Price,
                Street = hostel.Street,
                TotalArea = hostel.TotalArea,
                TypeSale = hostel.TypeSale
            };
            var responseCreated = await hostelService.Create(hostelCreateRequest);

            // Act
            var responseDeleted = await hostelService.Delete(responseCreated.Data!.IdHostel);

            // Assert
            Assert.True(responseDeleted.IsSuccses);
        }
    }
}
