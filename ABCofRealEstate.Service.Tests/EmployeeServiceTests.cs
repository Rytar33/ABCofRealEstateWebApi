using ABCofRealEstate.Services.Interfaces.Services;
using ABCofRealEstate.Services.Models.Employees;
using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Service.Tests
{
    public class EmployeeServiceTests
    {
        private EmployeeCreateRequest GetEmployeeCreateRequest()
        {
            ITestDataGenerator testDataGenerator = new TestDataGenerator();
            var employee = testDataGenerator.GetGenerationEmployee();
            return new EmployeeCreateRequest(
                employee.Email,
                employee.FullName,
                employee.JobTitle,
                employee.NumberPhone,
                null);
        }
        [Fact]
        public async Task GetEmployeeFromServiceTest()
        {
            // Arrange
            IEmployeeService employeeService = new EmployeeService();
            var employeeCreateRequest = GetEmployeeCreateRequest();
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Act
            var responseGet = await employeeService.Get(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseGet.IsSuccess && responseGet.Data != null);
            await employeeService.Delete(responseGet.Data!.Id);
        }
        [Fact]
        public async Task GetEmployeesPageFromServiceTest()
        {
            // Arrange
            IEmployeeService employeeService = new EmployeeService();
            var employeeListRequest = new EmployeeListRequest(new PageRequest());
            
            // Act
            var employeeListResponse = await employeeService.GetPage(employeeListRequest);

            // Assert
            Assert.True(employeeListResponse.IsSuccess);
        }
        [Fact]
        public async Task AddEmployeeInServiceTest()
        {
            // Arrange
            IEmployeeService employeeService = new EmployeeService();
            var employeeCreateRequest = GetEmployeeCreateRequest();

            // Act
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccess && responseCreated.Data != null);
            await employeeService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task UpdateEmployeeInServiceTest()
        {
            // Arrange
            IEmployeeService employeeService = new EmployeeService();
            var employeeCreateRequest = GetEmployeeCreateRequest();
            var responseCreated = await employeeService.Create(employeeCreateRequest);
            var employeeChangeRequest = new EmployeeChangeRequest(
                responseCreated.Data!.Id,
                responseCreated.Data!.Email,
                responseCreated.Data!.FullName,
                responseCreated.Data!.JobTitle,
                "3231-3333-888");

            // Act
            var responseUpdater = await employeeService.Change(employeeChangeRequest);

            // Assert
            Assert.True(responseUpdater.IsSuccess 
                && responseUpdater.Data != null
                && responseUpdater.Data.NumberPhone == employeeChangeRequest.NumberPhone);
            await employeeService.Delete(responseCreated.Data!.Id);
        }
        [Fact]
        public async Task DeleteEmployeeFromServiceTest()
        {
            // Arrange
            IEmployeeService employeeService = new EmployeeService();
            var employeeCreateRequest = GetEmployeeCreateRequest();
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Act
            var responseDeleted = await employeeService.Delete(responseCreated.Data!.Id);

            // Assert
            Assert.True(responseDeleted.IsSuccess);
        }
    }
}
