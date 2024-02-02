using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services.Validations.Houses
{
    public static class ValidationHouseCreateRequest
    {
        public static BaseResponse<HouseDetailResponse> GetResultValidation(this HouseCreateRequest houseCreateRequest)
        {

            return new BaseResponse<HouseDetailResponse> { IsSuccses = true };
        }
    }
}
