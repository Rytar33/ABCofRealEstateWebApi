using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Rooms;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Rooms;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services
{
    public class RoomService
    {
        public async Task<BaseResponse<RoomDetailResponse>> Create(RoomCreateRequest roomCreateRequest)
        {
            var resultValidation = roomCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (roomCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Room
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<RoomDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var room = new Room()
            {
                CountRooms = roomCreateRequest.CountRooms,
                CountFloorsHouse = roomCreateRequest.CountFloorsHouse,
                LocatedFloorApartament = roomCreateRequest.LocatedFloorApartament,
                ConditionHouse = roomCreateRequest.ConditionHouse,
                CountBalcony = roomCreateRequest.CountBalcony,
                Description = roomCreateRequest.Description,
                District = roomCreateRequest.District,
                EmployeeId = roomCreateRequest.IdEmployee,
                KitchenArea = roomCreateRequest.KitchenArea,
                NumberApartament = roomCreateRequest.NumberApartament,
                TotalArea = roomCreateRequest.TotalArea,
                TypeSale = roomCreateRequest.TypeSale,
                LivingSpace = roomCreateRequest.LivingSpace,
                IsCorner = roomCreateRequest.IsCorner,
                Locality = roomCreateRequest.Locality,
                MaterialHouse = roomCreateRequest.MaterialHouse,
                NumberProperty = roomCreateRequest.NumberProperty,
                Price = roomCreateRequest.Price,
                Street = roomCreateRequest.Street,
                DateTimePublished = DateTime.Now,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : roomCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.Room.AddAsync(room);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                roomCreateRequest.Files);
            return await Get(room.Id);
        }
        public async Task<BaseResponse<RoomDetailResponse>> Change(RoomChangeRequest roomChangeRequest)
        {
            var resultValidation = roomChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var roomGet = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == roomChangeRequest.IdRoom);
            if(roomGet == null)
                return new BaseResponse<RoomDetailResponse>()
                {
                    IsSuccses = false,
                    ErrorMessage = "Комнаты не было найдено"
                };
            var room = new Room()
            {
                Id = roomChangeRequest.IdRoom,
                CountRooms = roomChangeRequest.CountRooms,
                CountFloorsHouse = roomChangeRequest.CountFloorsHouse,
                LocatedFloorApartament = roomChangeRequest.LocatedFloorApartament,
                ConditionHouse = roomChangeRequest.ConditionHouse,
                CountBalcony = roomChangeRequest.CountBalcony,
                Description = roomChangeRequest.Description,
                District = roomChangeRequest.District,
                EmployeeId = roomChangeRequest.IdEmployee,
                KitchenArea = roomChangeRequest.KitchenArea,
                NumberApartament = roomChangeRequest.NumberApartament,
                TotalArea = roomChangeRequest.TotalArea,
                TypeSale = roomChangeRequest.TypeSale,
                LivingSpace = roomChangeRequest.LivingSpace,
                IsCorner = roomChangeRequest.IsCorner,
                Locality = roomChangeRequest.Locality,
                MaterialHouse = roomChangeRequest.MaterialHouse,
                NumberProperty = roomChangeRequest.NumberProperty,
                Price = roomChangeRequest.Price,
                Street = roomChangeRequest.Street,
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
            using var db = new RealEstateDataContext();
            var room = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
                return new BaseResponse<RoomDetailResponse>() { IsSuccses = false, ErrorMessage = "Комната не была найдена" };
            var responseEmployee =
               room.EmployeeId is not null
               ? await new EmployeeService().Get((Guid)room.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{room.SourceRealEstateObjectId}");
            return new BaseResponse<RoomDetailResponse>()
            {
                IsSuccses = true,
                Data = new RoomDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    Employee = responseEmployee?.Data,
                    CountFloorsHouse = room.CountFloorsHouse,
                    LocatedFloorApartament = room.LocatedFloorApartament,
                    ConditionHouse = room.ConditionHouse,
                    CountBalcony = room.CountBalcony,
                    CountRooms = room.CountRooms,
                    DateTimePublished = room.DateTimePublished,
                    Description = room.Description,
                    District = room.District,
                    IdRoom = room.Id,
                    IsActual = room.IsActual,
                    IsCorner = room.IsCorner,
                    KitchenArea = room.KitchenArea,
                    LivingSpace = room.LivingSpace,
                    Locality = room.Locality,
                    MaterialHouse = room.MaterialHouse,
                    NumberApartament = room.NumberApartament,
                    NumberProperty = room.NumberProperty,
                    Price = room.Price,
                    Street = room.Street,
                    TotalArea = room.TotalArea,
                    TypeSale = room.TypeSale
                }
            };
        }
        public async Task<BaseResponse<RoomDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var room = await db.Room.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            if (room == null)
                return new BaseResponse<RoomDetailResponse>() { IsSuccses = false, ErrorMessage = "Комната не была найдена" };
            Guid idSourceObject = room.SourceRealEstateObjectId;
            db.Room.Remove(room);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<RoomDetailResponse>() { IsSuccses = true };
        }
    }
}
