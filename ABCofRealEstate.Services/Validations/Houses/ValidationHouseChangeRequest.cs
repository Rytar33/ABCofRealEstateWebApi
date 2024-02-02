using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Hostels;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services.Validations.Houses
{
    public static class ValidationHouseChangeRequest
    {
        public static BaseResponse<HouseDetailResponse> GetResultValidation(this HouseChangeRequest houseChangeRequest)
        {

            return new BaseResponse<HouseDetailResponse> { IsSuccses = true };
        }
    }
}
