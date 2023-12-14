using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeCreateRequest
    {
        public int? IdImg { get; set; }
        public Image? Image { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public EnumJobTitleEmployee JobTitle { get; set; }
        public string NumberPhone { get; set; } = null!;
    }
}
