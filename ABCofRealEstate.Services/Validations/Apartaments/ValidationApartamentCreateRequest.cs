using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services.Validations.Apartaments
{
    public static class ValidationApartamentCreateRequest
    {
        public static BaseResponse GetResultValidation(this ApartamentCreateRequest apartamentCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
