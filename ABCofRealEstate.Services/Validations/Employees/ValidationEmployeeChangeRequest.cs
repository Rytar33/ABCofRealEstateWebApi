using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Employees;

namespace ABCofRealEstate.Services.Validations.Employees
{
    public static class ValidationEmployeeChangeRequest
    {
        public static BaseResponse<EmployeeDetailResponse> GetResultValidation(this EmployeeChangeRequest employeeChangeRequest)
        {

            return new BaseResponse<EmployeeDetailResponse> { IsSuccess = true };
        }
    }
}
