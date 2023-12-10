using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Services.Validations.Garages
{
    public static class ValidationGarageCreateRequest
    {
        public static BaseResponse GetResultValidation(this GarageCreateRequest garageCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
