using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeListResponse
    {
        public EmployeeListResponse(
            IEnumerable<EmployeeListItem> items,
            PageResponse? page)
        {
            Items = items;
            Page = page;
        }
        public IEnumerable<EmployeeListItem> Items { get; init; }
        public PageResponse? Page { get; init; }
    }
}
