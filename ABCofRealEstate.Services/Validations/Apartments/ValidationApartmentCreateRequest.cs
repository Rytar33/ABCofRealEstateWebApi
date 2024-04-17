using ABCofRealEstate.Services.Models.Apartments;

namespace ABCofRealEstate.Services.Validations.Apartments
{
    public static class ValidationApartmentCreateRequest
    {
        public static BaseResponse<ApartmentDetailResponse> GetResultValidation(this ApartmentCreateRequest apartmentCreateRequest)
        {

            return new BaseResponse<ApartmentDetailResponse> { IsSuccess = true };
        }
    }
}
