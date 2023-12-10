using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Services.Validations.Hostels
{
    public static class ValidationHostelCreateRequest
    {
        public static BaseResponse GetResultValidation(this HostelCreateRequest hostelCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
