using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.Services.Validations.Commertions
{
    public static class ValidationCommertionCreateRequest
    {
        public static BaseResponse<CommertionDetailResponse> GetResultValidation(this CommertionCreateRequest commertionCreateRequest)
        {

            return new BaseResponse<CommertionDetailResponse> { IsSuccses = true };
        }
    }
}
