using ABCofRealEstate.Services.Models;

namespace ABCofRealEstate.Services.Validations
{
    public static class ValidationApartamentCreateRequest
    {
        public static BaseResponse GetResultValidation()
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
