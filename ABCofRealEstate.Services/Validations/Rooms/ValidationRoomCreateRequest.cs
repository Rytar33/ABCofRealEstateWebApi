using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services.Validations.Rooms
{
    public static class ValidationRoomCreateRequest
    {
        public static BaseResponse GetResultValidation(this RoomCreateRequest roomCreateRequest)
        {

            return new BaseResponse { IsSuccses = true };
        }
    }
}
