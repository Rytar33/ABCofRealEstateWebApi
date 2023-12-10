using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services.Validations.Houses
{
    public static class ValidationHouseCreateRequest
    {
        public static BaseResponse GetResultValidation(this HouseCreateRequest houseCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
