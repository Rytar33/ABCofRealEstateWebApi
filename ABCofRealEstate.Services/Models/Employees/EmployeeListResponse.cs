using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeListResponse
    {
        public IEnumerable<EmployeeListItem> Items { get; set; }
        public PageResponse? Page { get; set; }
    }
}
