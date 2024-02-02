using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Services.Validations.Garages
{
    public static class ValidationGarageChangeRequest
    {
        public static BaseResponse<GarageDetailResponse> GetResultValidation(this GarageChangeRequest garageChangeRequest)
        {

            return new BaseResponse<GarageDetailResponse> { IsSuccses = true };
        }
    }
}
