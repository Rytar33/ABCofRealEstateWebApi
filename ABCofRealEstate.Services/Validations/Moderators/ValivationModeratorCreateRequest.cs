using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Moderators;

namespace ABCofRealEstate.Services.Validations.Moderators
{
    public static class ValivationModeratorCreateRequest
    {
        public static BaseResponse<ModeratorDetailResponse> GetResultValidation(this ModeratorCreateRequest moderatorChangeRequest)
        {

            return new BaseResponse<ModeratorDetailResponse> { IsSuccess = true };
        }
    }
}
