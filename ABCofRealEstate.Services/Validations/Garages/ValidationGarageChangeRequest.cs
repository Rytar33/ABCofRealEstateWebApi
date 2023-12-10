using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Services.Validations.Garages
{
    public static class ValidationGarageChangeRequest
    {
        public static BaseResponse GetResultValidation(this GarageChangeRequest garageChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
