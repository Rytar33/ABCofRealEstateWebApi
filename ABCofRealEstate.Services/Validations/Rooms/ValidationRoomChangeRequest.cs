using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services.Validations.Rooms
{
    public static class ValidationRoomChangeRequest
    {
        public static BaseResponse<RoomDetailResponse> GetResultValidation(this RoomChangeRequest roomChangeRequest)
        {

            return new BaseResponse<RoomDetailResponse> { IsSuccses = true };
        }
    }
}
