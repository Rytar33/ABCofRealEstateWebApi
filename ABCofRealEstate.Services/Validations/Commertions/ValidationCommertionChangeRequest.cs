using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Commertions;

namespace ABCofRealEstate.Services.Validations.Commertions
{
    public static class ValidationCommertionChangeRequest
    {
        public static BaseResponse GetResultValidation(this CommertionChangeRequest commertionChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
