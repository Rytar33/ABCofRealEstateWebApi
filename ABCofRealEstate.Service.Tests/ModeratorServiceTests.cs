using ABCofRealEstate.Services.Models.Moderators;
using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Service.Tests
{
    public class ModeratorServiceTests
    {
        private ModeratorCreateRequest GetModeratorCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var moderator = testDataGenerator.GetGenerationModerator();
            return new ModeratorCreateRequest(
                moderator.Name,
                moderator.Email,
                moderator.Password,
                moderator.AccessLevel);
        }
        [Fact]
        public async Task GetPageModeratorsFromServiceTest()
        {
            // Arrange
            IModeratorService serviceModerator = new ModeratorService();
            var moderatorListRequest = new ModeratorListRequest(
                null,
                false,
                accessLevel: EnumAccessLevel.Delete,
                page: new PageRequest());
            
            // Act
            var responseListModerator = await serviceModerator.GetPage(moderatorListRequest);

            // Assert
            Assert.True(responseListModerator.IsSuccess 
                        && responseListModerator.Data!.Items.All(i => 
                            i.IsSuperModerator == moderatorListRequest.IsSuperModerator
                            && i.AccessLevel == moderatorListRequest.AccessLevel));
        }
        [Fact]
        public async Task GetModeratorFromServiceTest()
        {
            // Arrange
            IModeratorService serviceModerator = new ModeratorService();
            var moderatorCreateRequest = GetModeratorCreateRequest();
            var responseCreated = await serviceModerator.Create(moderatorCreateRequest);
            
            // Act
            var responseGet = await serviceModerator.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess & responseGet.Data != null);
            await serviceModerator.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task AddModeratorInServiceTest()
        {
            // Arrange
            IModeratorService serviceModerator = new ModeratorService();
            var moderatorCreateRequest = GetModeratorCreateRequest();
            
            // Act
            var responseCreated = await serviceModerator.Create(moderatorCreateRequest);
            
            // Assert
            Assert.True(responseCreated.IsSuccess & responseCreated.Data != null);
            //await serviceModerator.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateModeratorInServiceTest()
        {
            // Arrange
            IModeratorService serviceModerator = new ModeratorService();
            var moderatorCreateRequest = GetModeratorCreateRequest();
            var responseCreated = await serviceModerator.Create(moderatorCreateRequest);
            var moderatorChangeRequest = new ModeratorChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.Name,
                responseCreated.Data!.Email,
                responseCreated.Data!.AccessLevel,
                true);
            
            // Act
            var responseChanged = await serviceModerator.Change(moderatorChangeRequest);
            
            // Assert
            Assert.True(responseChanged.IsSuccess 
                        && responseChanged.Data != null
                        && responseChanged.Data.IsSuperModerator == moderatorChangeRequest.IsSuperModerator);
            await serviceModerator.Delete(responseChanged.Data!.Id);
        }
        [Fact]
        public async Task DeleteModeratorFromServiceTest()
        {
            // Arrange
            IModeratorService serviceModerator = new ModeratorService();
            var moderatorCreateRequest = GetModeratorCreateRequest();
            var responseCreated = await serviceModerator.Create(moderatorCreateRequest);
            
            // Act
            var responseDeleted = await serviceModerator.Delete(responseCreated.Data!.Id);
            
            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
