using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeCreateRequest
    {
        public EmployeeCreateRequest(
            string email,
            string fullName,
            EnumJobTitleEmployee jobTitle,
            string numberPhone,
            IFormFile? file)
        {
            Email = email;
            FullName = fullName;
            JobTitle = jobTitle;
            NumberPhone = numberPhone;
            File = file;
        }
        public EmployeeCreateRequest()
        {
            
        }
        public string Email { get; init; }
        public string FullName { get; init; }
        public EnumJobTitleEmployee JobTitle { get; init; }
        public string NumberPhone { get; init; }
        public IFormFile? File { get; init; }
    }
}
