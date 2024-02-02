using ABCofRealEstate.Services.Models.Page;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Service.Tests
{
    public class SourceRealEstateObjectServiceTests
    {
        [Fact]
        public async Task GetRealEstateObjectsPageFromServiceTest()
        {
            // Arrange


            // Act
            var realEstatePage = await new SourceRealEstateObjectService()
                .GetList(new SourceRealEstateObjectListRequest()
                {
                    Page = new PageRequest()
                    {
                        Page = 1,
                        PageSize = 4
                    },
                    TypeObject = EnumObject.Area
                });

            // Assert
            Assert.True(realEstatePage.IsSuccses && realEstatePage.Data!.Items.Any());
        }
        [Fact]
        public async Task AddSourceRealEstateObjectInServiceTest()
        {
            // Arrange

            // Act

            // Assert

        }
        [Fact]
        public async Task DeleteSourceRealEstateObjectFromServiceTest()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
