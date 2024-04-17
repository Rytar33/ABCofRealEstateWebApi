using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.Services.Validations.Areas
{
    public static class ValidationAreaChangeRequest
    {
        public static BaseResponse<AreaDetailResponse> GetResultValidation(this AreaChangeRequest areaChangeRequest)
        {

            return new BaseResponse<AreaDetailResponse> { IsSuccess = true };
        }
    }
}
