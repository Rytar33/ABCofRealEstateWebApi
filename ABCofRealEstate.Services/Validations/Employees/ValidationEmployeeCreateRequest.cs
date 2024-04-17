using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Validations.Employees
{
    public static class ValidationEmployeeCreateRequest
    {
        public static BaseResponse<EmployeeDetailResponse> GetResultValidation(this EmployeeCreateRequest employeeCreateRequest)
        {

            return new BaseResponse<EmployeeDetailResponse> { IsSuccess = true };
        }
    }
}
