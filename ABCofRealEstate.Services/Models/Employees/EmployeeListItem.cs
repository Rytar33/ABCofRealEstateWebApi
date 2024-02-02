using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeListItem
    {
        public string? FullPathFile { get; set; }
        public Guid IdEmployee { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public EnumJobTitleEmployee JobTitle { get; set; }
        public string NumberPhone { get; set; } = null!;
    }
}
