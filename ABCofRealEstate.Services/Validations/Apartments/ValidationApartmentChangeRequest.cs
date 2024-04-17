using ABCofRealEstate.Services.Models.Apartments;

namespace ABCofRealEstate.Services.Validations.Apartments
{
    public static class ValidationApartmentChangeRequest
    {
        public static BaseResponse<ApartmentDetailResponse> GetResultValidation(this ApartmentChangeRequest apartmentChangeRequest)
        {

            return new BaseResponse<ApartmentDetailResponse> { IsSuccess = true };
        }
    }
}
