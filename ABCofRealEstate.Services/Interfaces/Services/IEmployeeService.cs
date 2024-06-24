using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IEmployeeService :
    IServiceCreate<EmployeeDetailResponse, EmployeeCreateRequest>,
    IServiceGet<EmployeeDetailResponse>,
    IServiceChange<EmployeeDetailResponse, EmployeeChangeRequest>,
    IServiceDelete<EmployeeDetailResponse>,
    IServiceGetPage<EmployeeListRequest, EmployeeListResponse>
{
    Task<BaseResponse<IEnumerable<EmployeeGetShortListResponse>>> GetShortList();
}