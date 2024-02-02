using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Commertions;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Commertions;
using ABCofRealEstate.Data.Enums;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services
{
    public class CommertionService
    {
        public async Task<BaseResponse<CommertionDetailResponse>> Create(CommertionCreateRequest commertionCreateRequest)
        {
            var resultValidation = commertionCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (commertionCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Commertion
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<CommertionDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var commertion = new Commertion()
            {
                Description = commertionCreateRequest.Description,
                District = commertionCreateRequest.District,
                Street = commertionCreateRequest.Street,
                CountRooms = commertionCreateRequest.CountRooms,
                CountFloorsHouse = commertionCreateRequest.CountFloorsHouse,
                LocatedFloorApartament = commertionCreateRequest.LocatedFloorApartament,
                EmployeeId = commertionCreateRequest.IdEmployee,
                IsCorner = commertionCreateRequest.IsCorner,
                Locality = commertionCreateRequest.Locality,
                MaterialHouse = commertionCreateRequest.MaterialHouse,
                NumberProperty = commertionCreateRequest.NumberProperty,
                Price = commertionCreateRequest.Price,
                RoomArea = commertionCreateRequest.RoomArea,
                TypeSale = commertionCreateRequest.TypeSale,
                DateTimePublished = DateTime.Now,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : commertionCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.Commertion.AddAsync(commertion);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                commertionCreateRequest.Files);
            return await Get(commertion.Id);
        }
        public async Task<BaseResponse<CommertionDetailResponse>> Change(CommertionChangeRequest commertionChangeRequest)
        {
            var resultValidation = commertionChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();
            var commertionGet = await db.Commertion.AsNoTracking().FirstOrDefaultAsync(a => a.Id == commertionChangeRequest.IdCommertion);
            if (commertionGet == null)
                return new BaseResponse<CommertionDetailResponse>() 
                {
                    IsSuccses = false,
                    ErrorMessage = "Объект под коммерцию не был найден"
                };
            var commertion = new Commertion()
            {
                Id = commertionChangeRequest.IdCommertion,
                Description = commertionChangeRequest.Description,
                District = commertionChangeRequest.District,
                Street = commertionChangeRequest.Street,
                CountRooms = commertionChangeRequest.CountRooms,
                CountFloorsHouse = commertionChangeRequest.CountFloorsHouse,
                LocatedFloorApartament = commertionChangeRequest.LocatedFloorApartament,
                EmployeeId = commertionChangeRequest.IdEmployee,
                IsCorner = commertionChangeRequest.IsCorner,
                Locality = commertionChangeRequest.Locality,
                MaterialHouse = commertionChangeRequest.MaterialHouse,
                NumberProperty = commertionChangeRequest.NumberProperty,
                Price = commertionChangeRequest.Price,
                RoomArea = commertionChangeRequest.RoomArea,
                TypeSale = commertionChangeRequest.TypeSale,
                DateTimePublished = commertionGet.DateTimePublished,
                IsActual = commertionChangeRequest.IsActual,
                SourceRealEstateObjectId = commertionGet.SourceRealEstateObjectId
            };
            db.Commertion.Update(commertion);
            await db.SaveChangesAsync();
            return await Get(commertion.Id);
        }
        public async Task<BaseResponse<CommertionDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var commertion = await db.Commertion.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (commertion == null)
                return new BaseResponse<CommertionDetailResponse>() { IsSuccses = false, ErrorMessage = "Объект под комерцию не был найден" };
            var responseEmployee =
                commertion.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)commertion.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{commertion.SourceRealEstateObjectId}");
            return new BaseResponse<CommertionDetailResponse>()
            {
                IsSuccses = true,
                Data = new CommertionDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    CountFloorsHouse = commertion.CountFloorsHouse,
                    LocatedFloorApartament = commertion.LocatedFloorApartament,
                    CountRooms = commertion.CountRooms,
                    IdCommertion = commertion.Id,
                    IsCorner = commertion.IsCorner,
                    DateTimePublished = commertion.DateTimePublished,
                    Description = commertion.Description,
                    District = commertion.District,
                    Employee = responseEmployee?.Data,
                    IsActual = commertion.IsActual,
                    Locality = commertion.Locality,
                    MaterialHouse = commertion.MaterialHouse,
                    NumberProperty = commertion.NumberProperty,
                    Price = commertion.Price,
                    RoomArea = commertion.RoomArea,
                    Street = commertion.Street,
                    TypeSale = commertion.TypeSale
                }
            };
        }
        public async Task<BaseResponse<CommertionDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var commertion = await db.Commertion.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (commertion == null)
                return new BaseResponse<CommertionDetailResponse>() { IsSuccses = false, ErrorMessage = "Объект под комерцию не был найден" };
            var idSource = commertion.SourceRealEstateObjectId;
            db.Commertion.Remove(commertion);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSource);
            return new BaseResponse<CommertionDetailResponse>() { IsSuccses = true };
        }
    }
}
