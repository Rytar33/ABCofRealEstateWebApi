using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Images;

namespace ABCofRealEstate.Services.Validations.Images
{
    public static class ValidationImageCreateRequest
    {
        public static BaseResponse GetResultValidation(this ImageCreateRequest imageCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
