using ABCofRealEstate.Services.Models.Page;

namespace ABCofRealEstate.Services.Models.Employees
{
    public class EmployeeListRequest
    {
        public EmployeeListRequest(PageRequest? page) => Page = page ?? new PageRequest();
        public EmployeeListRequest() => Page ??= new PageRequest();
        public PageRequest? Page { get; set; }
    }
}
