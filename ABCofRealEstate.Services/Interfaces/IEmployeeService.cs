using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Interfaces;

public interface IEmployeeService : 
    IServiceCreate<EmployeeDetailResponse, EmployeeCreateRequest>, 
    IServiceGet<EmployeeDetailResponse>,
    IServiceChange<EmployeeDetailResponse, EmployeeChangeRequest>,
    IServiceDelete<EmployeeDetailResponse>,
    IServiceGetPage<EmployeeListRequest, EmployeeListResponse>
{}