using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.Services.Validations.Commertions
{
    public static class ValidationCommertionChangeRequest
    {
        public static BaseResponse<CommertionDetailResponse> GetResultValidation(this CommertionChangeRequest commertionChangeRequest)
        {

            return new BaseResponse<CommertionDetailResponse> { IsSuccses = true };
        }
    }
}
