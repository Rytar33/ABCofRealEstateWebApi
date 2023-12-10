using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Services.Validations.Hostels
{
    public static class ValidationHostelChangeRequest
    {
        public static BaseResponse GetResultValidation(this HostelChangeRequest hostelChangeRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
