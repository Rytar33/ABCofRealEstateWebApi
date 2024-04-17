using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Services.Validations.Hostels
{
    public static class ValidationHostelCreateRequest
    {
        public static BaseResponse<HostelDetailResponse> GetResultValidation(this HostelCreateRequest hostelCreateRequest)
        {

            return new BaseResponse<HostelDetailResponse> { IsSuccess = true };
        }
    }
}
