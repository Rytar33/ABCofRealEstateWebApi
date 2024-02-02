using ABCofRealEstate.Data.Enums;
using Microsoft.AspNetCore.Http;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeCreateRequest
    {
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public EnumJobTitleEmployee JobTitle { get; set; }
        public string NumberPhone { get; set; } = null!;
        public IFormFile? File { get; set; }
    }
}
