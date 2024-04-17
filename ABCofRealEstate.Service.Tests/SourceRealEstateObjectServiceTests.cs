using ABCofRealEstate.Services.Models.Page;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using Bogus;

namespace ABCofRealEstate.Service.Tests
{
    public class SourceRealEstateObjectServiceTests
    {
        [Fact]
        public async Task GetRealEstateObjectsPageFromServiceTest()
        {
            // Arrange
            ISourceRealEstateObjectService sourceRealEstateObjectService = new SourceRealEstateObjectService();
            
            // Act
            var realEstatePage = await sourceRealEstateObjectService
                .GetPage(new SourceRealEstateObjectListRequest(
                    EnumObject.Area,
                    null,
                    null,
                    null,
                    null));

            // Assert
            Assert.True(realEstatePage.IsSuccess);
        }
        [Fact]
        public async Task AddSourceRealEstateObjectInServiceTest()
        {
            // Arrange
            ISourceRealEstateObjectService sourceRealEstateObjectService = new SourceRealEstateObjectService();
            var sourceRealEstateObjectCreateRequest = 
                new SourceRealEstateObjectCreateRequest(new Faker().PickRandom<EnumObject>());
            
            // Act
            var responseCreated = await sourceRealEstateObjectService.Create(sourceRealEstateObjectCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess & responseCreated.Data != null);
            await sourceRealEstateObjectService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task DeleteSourceRealEstateObjectFromServiceTest()
        {
            // Arrange
            ISourceRealEstateObjectService sourceRealEstateObjectService = new SourceRealEstateObjectService();
            var sourceRealEstateObjectCreateRequest = 
                new SourceRealEstateObjectCreateRequest(new Faker().PickRandom<EnumObject>());
            var responseCreated = await sourceRealEstateObjectService.Create(sourceRealEstateObjectCreateRequest);
            
            // Act
            var responseDeleted = await sourceRealEstateObjectService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
            
        }
    }
}
