using ABCofRealEstate.Services.Models.Comertions;

namespace ABCofRealEstate.Services.Validations.Comertions
{
    public static class ValidationComertionChangeRequest
    {
        public static BaseResponse<ComertionDetailResponse> GetResultValidation(this ComertionChangeRequest comertionChangeRequest)
        {

            return new BaseResponse<ComertionDetailResponse> { IsSuccess = true };
        }
    }
}
