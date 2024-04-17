using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services.Interfaces;

public interface IRoomService : 
    IServiceCreate<RoomDetailResponse, RoomCreateRequest>, 
    IServiceGet<RoomDetailResponse>,
    IServiceChange<RoomDetailResponse, RoomChangeRequest>,
    IServiceDelete<RoomDetailResponse>
{}