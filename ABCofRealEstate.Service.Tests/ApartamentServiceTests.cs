using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Service.Tests
{
    public class ApartamentServiceTests
    {
        [Fact]
        public async Task GetApartamentFromServiceTest()
        {
            //Arrange
            var apartamentService = new ApartamentService();
            var apartament = await new TestDataGenerator().GetGenerationApartament();
            ApartamentCreateRequest apartamentCreateRequest = new ApartamentCreateRequest()
            {
                LocatedFloorApartament = apartament.LocatedFloorApartament,
                CountBalcony = apartament.CountBalcony,
                CountRooms = apartament.CountRooms,
                Locality = apartament.Locality,
                ConditionHouse = apartament.ConditionHouse,
                CountFloorsHouse = apartament.CountFloorsHouse,
                IsCorner = apartament.IsCorner,
                Description = apartament.Description,
                District = apartament.District,
                EmployeeId = apartament.EmployeeId,
                KitchenArea = apartament.KitchenArea,
                LivingSpace = apartament.LivingSpace,
                TotalArea = apartament.TotalArea,
                MaterialHouse = apartament.MaterialHouse,
                Price = apartament.Price,
                NumberApartament = apartament.NumberApartament,
                NumberProperty = apartament.NumberProperty,
                Street = apartament.Street,
                TypeSale = apartament.TypeSale
            };
            var responseCreated = await apartamentService.Create(apartamentCreateRequest);

            //Act
            var responseGet = await apartamentService.Get(responseCreated.Data!.IdApartament);

            //Assert
            Assert.True(responseGet.IsSuccses);
            await apartamentService.Delete(responseGet.Data!.IdApartament);
        }
        [Fact]
        public async Task AddApartamentInServiceTest()
        {
            //Arrange
            var apartamentService = new ApartamentService();
            var apartament = await new TestDataGenerator().GetGenerationApartament();
            ApartamentCreateRequest apartamentCreateRequest = new ApartamentCreateRequest()
            {
                LocatedFloorApartament = apartament.LocatedFloorApartament,
                CountBalcony = apartament.CountBalcony,
                CountRooms = apartament.CountRooms,
                Locality = apartament.Locality,
                ConditionHouse = apartament.ConditionHouse,
                CountFloorsHouse = apartament.CountFloorsHouse,
                IsCorner = apartament.IsCorner,
                Description = apartament.Description,
                District = apartament.District,
                EmployeeId = apartament.EmployeeId,
                KitchenArea = apartament.KitchenArea,
                LivingSpace = apartament.LivingSpace,
                TotalArea = apartament.TotalArea,
                MaterialHouse = apartament.MaterialHouse,
                Price = apartament.Price,
                NumberApartament = apartament.NumberApartament,
                NumberProperty = apartament.NumberProperty,
                Street = apartament.Street,
                TypeSale = apartament.TypeSale
            };

            //Act
            var response = await apartamentService.Create(apartamentCreateRequest);

            //Assert
            Assert.NotNull(response.Data);
            await apartamentService.Delete(response.Data!.IdApartament);
        }
        [Fact]
        public async Task UpdateApartamentInServiceTest()
        {
            //Arrange
            var apartamentService = new ApartamentService();
            var apartamentService2 = new ApartamentService();
            var employeeService = new EmployeeService();
            var apartament = await new TestDataGenerator().GetGenerationApartament();
            ApartamentCreateRequest apartamentCreateRequest = new ApartamentCreateRequest()
            {
                LocatedFloorApartament = apartament.LocatedFloorApartament,
                CountBalcony = apartament.CountBalcony,
                CountRooms = apartament.CountRooms,
                Locality = apartament.Locality,
                ConditionHouse = apartament.ConditionHouse,
                CountFloorsHouse = apartament.CountFloorsHouse,
                IsCorner = apartament.IsCorner,
                Description = apartament.Description,
                District = apartament.District,
                EmployeeId = apartament.EmployeeId,
                KitchenArea = apartament.KitchenArea,
                LivingSpace = apartament.LivingSpace,
                TotalArea = apartament.TotalArea,
                MaterialHouse = apartament.MaterialHouse,
                Price = apartament.Price,
                NumberApartament = apartament.NumberApartament,
                NumberProperty = apartament.NumberProperty,
                Street = apartament.Street,
                TypeSale = apartament.TypeSale
            };
            var responseCreated = await apartamentService.Create(apartamentCreateRequest);
            var employee = await employeeService.Get(responseCreated.Data!.Employee!.IdEmployee);
            ApartamentChangeRequest apartamentChangeRequest = new ApartamentChangeRequest() 
            {
                IdApartament = responseCreated.Data!.IdApartament,
                LocatedFloorApartament = responseCreated.Data!.LocatedFloorApartament,
                CountBalcony = responseCreated.Data!.CountBalcony,
                CountRooms = responseCreated.Data!.CountRooms,
                Locality = responseCreated.Data!.Locality,
                ConditionHouse = responseCreated.Data!.ConditionHouse,
                CountFloorsHouse = responseCreated.Data!.CountFloorsHouse,
                IsCorner = responseCreated.Data!.IsCorner,
                Description = responseCreated.Data!.Description,
                District = responseCreated.Data!.District,
                EmployeeId = responseCreated.Data!.Employee!.IdEmployee,
                KitchenArea = responseCreated.Data!.KitchenArea,
                LivingSpace = responseCreated.Data!.LivingSpace,
                TotalArea = responseCreated.Data!.TotalArea,
                MaterialHouse = responseCreated.Data!.MaterialHouse,
                Price = 11111,
                NumberApartament = responseCreated.Data!.NumberApartament,
                NumberProperty = responseCreated.Data!.NumberProperty,
                Street = responseCreated.Data!.Street,
                TypeSale = responseCreated.Data!.TypeSale,
                IsActual = responseCreated.Data!.IsActual
            };

            //Act
            var responseChanged = await apartamentService2.Change(apartamentChangeRequest);

            //Assert
            Assert.Equal(11111, responseChanged.Data!.Price);
            await apartamentService.Delete(responseChanged.Data!.IdApartament);
        }
        [Fact]
        public async Task DeleteApartamentFromServiceTest()
        {
            //Arrange
            var apartamentService = new ApartamentService();
            var apartament = await new TestDataGenerator().GetGenerationApartament();
            ApartamentCreateRequest apartamentCreateRequest = new ApartamentCreateRequest()
            {
                LocatedFloorApartament = apartament.LocatedFloorApartament,
                CountBalcony = apartament.CountBalcony,
                CountRooms = apartament.CountRooms,
                Locality = apartament.Locality,
                ConditionHouse = apartament.ConditionHouse,
                CountFloorsHouse = apartament.CountFloorsHouse,
                IsCorner = apartament.IsCorner,
                Description = apartament.Description,
                District = apartament.District,
                EmployeeId = apartament.EmployeeId,
                KitchenArea = apartament.KitchenArea,
                LivingSpace = apartament.LivingSpace,
                TotalArea = apartament.TotalArea,
                MaterialHouse = apartament.MaterialHouse,
                Price = apartament.Price,
                NumberApartament = apartament.NumberApartament,
                NumberProperty = apartament.NumberProperty,
                Street = apartament.Street,
                TypeSale = apartament.TypeSale
            };
            var responseCreated = await apartamentService.Create(apartamentCreateRequest);

            if (responseCreated.IsSuccses == false)
                Assert.Fail(responseCreated.ErrorMessage);

            //Act
            var responseDeleted = await apartamentService.Delete(responseCreated.Data!.IdApartament);

            //Assert
            Assert.True(responseDeleted.IsSuccses);
        }
    }
}