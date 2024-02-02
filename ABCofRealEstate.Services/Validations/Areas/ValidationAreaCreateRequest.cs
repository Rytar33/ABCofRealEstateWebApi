using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.Services.Validations.Areas
{
    public static class ValidationAreaCreateRequest
    {
        public static BaseResponse<AreaDetailResponse> GetResultValidation(this AreaCreateRequest areaCreateRequest)
        {

            return new BaseResponse<AreaDetailResponse> { IsSuccses = true };
        }
    }
}
