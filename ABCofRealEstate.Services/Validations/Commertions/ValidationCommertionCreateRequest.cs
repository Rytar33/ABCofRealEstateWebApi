using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.Services.Validations.Commertions
{
    public static class ValidationCommertionCreateRequest
    {
        public static BaseResponse GetResultValidation(this CommertionCreateRequest commertionCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
