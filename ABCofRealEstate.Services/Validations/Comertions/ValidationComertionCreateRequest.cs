using ABCofRealEstate.Services.Models.Comertions;

namespace ABCofRealEstate.Services.Validations.Comertions
{
    public static class ValidationComertionCreateRequest
    {
        public static BaseResponse<ComertionDetailResponse> GetResultValidation(this ComertionCreateRequest comertionCreateRequest)
        {

            return new BaseResponse<ComertionDetailResponse> { IsSuccess = true };
        }
    }
}
