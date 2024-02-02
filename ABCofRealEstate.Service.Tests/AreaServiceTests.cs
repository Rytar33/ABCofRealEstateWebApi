using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.Service.Tests
{
    public class AreaServiceTests
    {
        [Fact]
        public async Task GetAreaFromServiceTest()
        {
            // Arrange
            var areaService = new AreaService();
            var area = await new TestDataGenerator().GetGenerationArea();
            var areaCreateRequest = new AreaCreateRequest()
            {
                Price = area.Price,
                Description = area.Description,
                LandArea = area.LandArea,
                Locality = area.Locality,
                District = area.District,
                EmployeeId = area.EmployeeId,
                Street = area.Street,
                TypeSale = area.TypeSale
            };
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Act
            var responseGet = await areaService.Get(responseCreated.Data!.IdArea);

            // Assert
            Assert.True(responseGet.IsSuccses);
            if (responseCreated.IsSuccses)
                await areaService.Delete(responseCreated.Data!.IdArea);
        }
        [Fact]
        public async Task AddAreaInServiceTest()
        {
            // Arrange
            var areaService = new AreaService();
            var area = await new TestDataGenerator().GetGenerationArea();
            var areaCreateRequest = new AreaCreateRequest()
            {
                Price = area.Price,
                Description = area.Description,
                LandArea = area.LandArea,
                Locality = area.Locality,
                District = area.District,
                EmployeeId = area.EmployeeId,
                Street = area.Street,
                TypeSale = area.TypeSale
            };

            // Act
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccses);
            //if (responseCreated.IsSuccses)
            //    await areaService.Delete(responseCreated.Data!.IdArea);
        }
        [Fact]
        public async Task UpdateAreaInServiceTest()
        {
            // Arrange
            var areaService = new AreaService();
            var area = await new TestDataGenerator().GetGenerationArea();
            var areaCreateRequest = new AreaCreateRequest()
            {
                Price = area.Price,
                Description = area.Description,
                LandArea = area.LandArea,
                Locality = area.Locality,
                District = area.District,
                EmployeeId = area.EmployeeId,
                Street = area.Street,
                TypeSale = area.TypeSale
            };
            var responseCreated = await areaService.Create(areaCreateRequest);
            var areaChangeRequest = new AreaChangeRequest()
            {
                IdArea = responseCreated.Data!.IdArea,
                Price = 11111,
                Description = responseCreated.Data!.Description,
                LandArea = responseCreated.Data!.LandArea,
                Locality = responseCreated.Data!.Locality,
                District = responseCreated.Data!.District,
                EmployeeId = responseCreated.Data!.Employee!.IdEmployee,
                Street = responseCreated.Data!.Street,
                TypeSale = responseCreated.Data!.TypeSale,
                IsActual = responseCreated.Data!.IsActual
            };

            // Act
            var responseUpdated = await areaService.Change(areaChangeRequest);

            // Assert
            Assert.Equal(11111, responseUpdated.Data!.Price);
            if (responseUpdated.IsSuccses)
                await areaService.Delete(responseUpdated.Data!.IdArea);
        }
        [Fact]
        public async Task DeleteAreaFromServiceTest()
        {
            // Arrange
            var areaService = new AreaService();
            var area = await new TestDataGenerator().GetGenerationArea();
            var areaCreateRequest = new AreaCreateRequest()
            {
                Price = area.Price,
                Description = area.Description,
                LandArea = area.LandArea,
                Locality = area.Locality,
                District = area.District,
                EmployeeId = area.EmployeeId,
                Street = area.Street,
                TypeSale = area.TypeSale
            };
            var responseCreated = await areaService.Create(areaCreateRequest);

            // Act
            var responseDelete = await areaService.Delete(responseCreated.Data!.IdArea);

            // Assert
            Assert.True(responseDelete.IsSuccses);
                
        }
    }
}
