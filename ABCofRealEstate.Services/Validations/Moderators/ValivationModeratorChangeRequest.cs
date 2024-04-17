using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Moderators;

namespace ABCofRealEstate.Services.Validations.Moderators
{
    public static class ValivationModeratorChangeRequest
    {
        public static BaseResponse<ModeratorDetailResponse> GetResultValidation(this ModeratorChangeRequest moderatorChangeRequest)
        {

            return new BaseResponse<ModeratorDetailResponse> { IsSuccess = true };
        }
    }
}
