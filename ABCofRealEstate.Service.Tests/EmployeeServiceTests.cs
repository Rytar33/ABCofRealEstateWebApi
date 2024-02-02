using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Service.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetEmployeeFromServiceTest()
        {
            // Arrange
            var employeeService = new EmployeeService();
            var employee = new TestDataGenerator().GetGenerationEmployee();
            var employeeCreateRequest = new EmployeeCreateRequest()
            {
                Email = employee.Email,
                FullName = employee.FullName,
                JobTitle = employee.JobTitle,
                NumberPhone = employee.NumberPhone
            };
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Act
            var responseGet = await employeeService.Get(responseCreated.Data!.IdEmployee);

            // Assert
            Assert.True(responseGet.IsSuccses && responseGet.Data != null);
            await employeeService.Delete(responseGet.Data!.IdEmployee);
        }
        [Fact]
        public async Task GetEmployeesPageFromServiceTest()
        {
            // Arrange

            // Act

            // Assert

        }
        [Fact]
        public async Task AddEmployeeInServiceTest()
        {
            // Arrange
            var employeeService = new EmployeeService();
            var employee = new TestDataGenerator().GetGenerationEmployee();
            var employeeCreateRequest = new EmployeeCreateRequest()
            {
                Email = employee.Email,
                FullName = employee.FullName,
                JobTitle = employee.JobTitle,
                NumberPhone = employee.NumberPhone
            };

            // Act
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Assert
            Assert.True(responseCreated.IsSuccses && responseCreated.Data != null);
            await employeeService.Delete(responseCreated.Data!.IdEmployee);
        }
        [Fact]
        public async Task UpdateEmployeeInServiceTest()
        {
            // Arrange
            var employeeService = new EmployeeService();
            var employee = new TestDataGenerator().GetGenerationEmployee();
            var employeeCreateRequest = new EmployeeCreateRequest()
            {
                Email = employee.Email,
                FullName = employee.FullName,
                JobTitle = employee.JobTitle,
                NumberPhone = employee.NumberPhone
            };
            var responseCreated = await employeeService.Create(employeeCreateRequest);
            var employeeChangeRequest = new EmployeeChangeRequest()
            {
                IdEmployee = responseCreated.Data!.IdEmployee,
                FullName = responseCreated.Data!.FullName,
                NumberPhone = "3231-3333-888",
                Email = responseCreated.Data!.Email,
                JobTitle= responseCreated.Data!.JobTitle,
            };

            // Act
            var responseUpdater = await employeeService.Change(employeeChangeRequest);

            // Assert
            Assert.True(responseUpdater.IsSuccses 
                && responseUpdater.Data != null
                && responseUpdater.Data.NumberPhone == employeeChangeRequest.NumberPhone);
            await employeeService.Delete(responseCreated.Data!.IdEmployee);
        }
        [Fact]
        public async Task DeleteEmployeeFromServiceTest()
        {
            // Arrange
            var employeeService = new EmployeeService();
            var employee = new TestDataGenerator().GetGenerationEmployee();
            var employeeCreateRequest = new EmployeeCreateRequest()
            {
                Email = employee.Email,
                FullName = employee.FullName,
                JobTitle = employee.JobTitle,
                NumberPhone = employee.NumberPhone
            };
            var responseCreated = await employeeService.Create(employeeCreateRequest);

            // Act
            var responseDeleted = await employeeService.Delete(responseCreated.Data!.IdEmployee);

            // Assert
            Assert.True(responseDeleted.IsSuccses);
        }
    }
}
