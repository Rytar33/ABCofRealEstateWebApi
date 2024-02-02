using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services.Validations.Apartaments
{
    public static class ValidationApartamentCreateRequest
    {
        public static BaseResponse<ApartamentDetailResponse> GetResultValidation(this ApartamentCreateRequest apartamentCreateRequest)
        {

            return new BaseResponse<ApartamentDetailResponse> { IsSuccses = true };
        }
    }
}
