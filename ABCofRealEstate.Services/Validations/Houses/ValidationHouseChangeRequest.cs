using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services.Validations.Houses
{
    public static class ValidationHouseChangeRequest
    {
        public static BaseResponse GetResultValidation(this HouseChangeRequest houseChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
