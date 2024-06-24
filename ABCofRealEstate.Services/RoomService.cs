using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services
{
    public class RoomService : IRoomService
    {
        public async Task<BaseResponse<RoomDetailResponse>> Create(RoomCreateRequest roomCreateRequest)
        {
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Room));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<RoomDetailResponse>()
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var room = new Room(
                roomCreateRequest.CountRooms,
                roomCreateRequest.District,
                roomCreateRequest.Street,
                roomCreateRequest.NumberApartment,
                roomCreateRequest.NumberProperty,
                roomCreateRequest.ConditionHouse,
                roomCreateRequest.LivingSpace,
                roomCreateRequest.TotalArea,
                roomCreateRequest.KitchenArea,
                roomCreateRequest.IsCorner,
                roomCreateRequest.CountFloorsHouse,
                roomCreateRequest.LocatedFloorApartment,
                roomCreateRequest.CountBalcony,
                roomCreateRequest.MaterialHouse,
                roomCreateRequest.Description,
                roomCreateRequest.Price,
                roomCreateRequest.EmployeeId,
                roomCreateRequest.TypeSale,
                roomCreateRequest.Locality,
                roomCreateRequest.Latitude,
                roomCreateRequest.Longitude)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.Room.AddAsync(room);
            await db.SaveChangesAsync();
            await ExportImageService
                .ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse.Data!.Id}",
                roomCreateRequest.Files);
            return await Get(room.Id);
        }
        public async Task<BaseResponse<RoomDetailResponse>> Change(RoomChangeRequest roomChangeRequest)
        {
            await using var db = new RealEstateDataContext();
            var roomGet = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == roomChangeRequest.Id);
            if(roomGet == null)
                return new BaseResponse<RoomDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Комнаты не было найдено"
                };
            var room = new Room(
                roomChangeRequest.CountRooms,
                roomChangeRequest.District,
                roomChangeRequest.Street,
                roomChangeRequest.NumberApartment,
                roomChangeRequest.NumberProperty,
                roomChangeRequest.ConditionHouse,
                roomChangeRequest.LivingSpace,
                roomChangeRequest.TotalArea,
                roomChangeRequest.KitchenArea,
                roomChangeRequest.IsCorner,
                roomChangeRequest.CountFloorsHouse,
                roomChangeRequest.LocatedFloorApartment,
                roomChangeRequest.CountBalcony,
                roomChangeRequest.MaterialHouse,
                roomChangeRequest.Description,
                roomChangeRequest.Price,
                roomChangeRequest.EmployeeId,
                roomChangeRequest.TypeSale,
                roomChangeRequest.Locality,
                roomChangeRequest.Latitude,
                roomChangeRequest.Longitude)
            {
                Id = roomChangeRequest.Id,
                IsActual = roomChangeRequest.IsActual,
                DateTimePublished = roomGet.DateTimePublished,
                SourceRealEstateObjectId = roomGet.SourceRealEstateObjectId
            };
            db.Room.Update(room);
            await db.SaveChangesAsync();
            return await Get(room.Id);
        }
        public async Task<BaseResponse<RoomDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var room = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
                return new BaseResponse<RoomDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Комната не была найдена"
                };
            var responseEmployee =
               room.EmployeeId is not null
               ? await new EmployeeService().Get((Guid)room.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{room.SourceRealEstateObjectId}");
            return new BaseResponse<RoomDetailResponse>
            {
                IsSuccess = true,
                Data = new RoomDetailResponse(
                    room.Id,
                    room.CountRooms,
                    room.District,
                    room.Street,
                    room.NumberApartment,
                    room.NumberProperty,
                    room.ConditionHouse,
                    room.LivingSpace,
                    room.TotalArea,
                    room.KitchenArea,
                    room.IsCorner,
                    room.CountFloorsHouse,
                    room.LocatedFloorApartment,
                    room.CountBalcony,
                    room.MaterialHouse,
                    room.Description,
                    room.Price,
                    responseEmployee?.Data,
                    room.TypeSale,
                    room.Locality,
                    room.IsActual,
                    room.DateTimePublished,
                    room.Latitude,
                    room.Longitude,
                    fullPathsImage)
            };
        }
        public async Task<BaseResponse<RoomDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var room = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
                return new BaseResponse<RoomDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Комната не была найдена"
                };
            var idSourceObject = room.SourceRealEstateObjectId;
            db.Room.Remove(room);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<RoomDetailResponse> { IsSuccess = true };
        }
    }
}
