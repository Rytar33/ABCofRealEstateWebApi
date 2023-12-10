using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services.Validations.Apartaments
{
    public static class ValidationApartamentChangeRequest
    {
        public static BaseResponse GetResultValidation(this ApartamentChangeRequest apartamentChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
