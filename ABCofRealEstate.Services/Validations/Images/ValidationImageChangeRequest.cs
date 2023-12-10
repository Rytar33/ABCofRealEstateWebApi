using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Images;

namespace ABCofRealEstate.Services.Validations.Images
{
    public static class ValidationImageChangeRequest
    {
        public static BaseResponse GetResultValidation(this ImageChangeRequest imageChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
