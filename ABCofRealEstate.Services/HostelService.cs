using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Hostels;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Hostels;
using ABCofRealEstate.Data.Enums;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services
{
    public class HostelService
    {
        public async Task<BaseResponse<HostelDetailResponse>> Create(HostelCreateRequest hostelCreateRequest)
        {
            var resultValidation = hostelCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (hostelCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Hostel
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<HostelDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var hostel = new Hostel()
            {
                CountRooms = hostelCreateRequest.CountRooms,
                CountFloorsHouse = hostelCreateRequest.CountFloorsHouse,
                LocatedFloorApartament = hostelCreateRequest.LocatedFloorApartament,
                ConditionHouse = hostelCreateRequest.ConditionHouse,
                Description = hostelCreateRequest.Description,
                CountBalcony = hostelCreateRequest.CountBalcony,
                District = hostelCreateRequest.District,
                Street = hostelCreateRequest.Street,
                EmployeeId = hostelCreateRequest.IdEmployee,
                TypeSale = hostelCreateRequest.TypeSale,
                TotalArea = hostelCreateRequest.TotalArea,
                IsCorner = hostelCreateRequest.IsCorner,
                KitchenArea = hostelCreateRequest.KitchenArea,
                LivingSpace = hostelCreateRequest.LivingSpace,
                Locality = hostelCreateRequest.Locality,
                MaterialHouse = hostelCreateRequest.MaterialHouse,
                NumberApartament = hostelCreateRequest.NumberApartament,
                NumberProperty = hostelCreateRequest.NumberProperty,
                Price = hostelCreateRequest.Price,
                DateTimePublished = DateTime.Now,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : hostelCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.Hostel.AddAsync(hostel);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                hostelCreateRequest.Files);
            return await Get(hostel.Id);
        }
        public async Task<BaseResponse<HostelDetailResponse>> Change(HostelChangeRequest hostelChangeRequest)
        {
            var resultValidation = hostelChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var hostelGet = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == hostelChangeRequest.IdHostel);
            if(hostelGet == null)
                return new BaseResponse<HostelDetailResponse>() 
                {
                    IsSuccses = false,
                    ErrorMessage = "Такой общаги не было найденно"
                };
            var hostel = new Hostel()
            {
                Id = hostelChangeRequest.IdHostel,
                CountRooms = hostelChangeRequest.CountRooms,
                CountFloorsHouse = hostelChangeRequest.CountFloorsHouse,
                LocatedFloorApartament = hostelChangeRequest.LocatedFloorApartament,
                ConditionHouse = hostelChangeRequest.ConditionHouse,
                Description = hostelChangeRequest.Description,
                CountBalcony = hostelChangeRequest.CountBalcony,
                District = hostelChangeRequest.District,
                Street = hostelChangeRequest.Street,
                EmployeeId = hostelChangeRequest.IdEmployee,
                TypeSale = hostelChangeRequest.TypeSale,
                TotalArea = hostelChangeRequest.TotalArea,
                IsCorner = hostelChangeRequest.IsCorner,
                KitchenArea = hostelChangeRequest.KitchenArea,
                LivingSpace = hostelChangeRequest.LivingSpace,
                Locality = hostelChangeRequest.Locality,
                MaterialHouse = hostelChangeRequest.MaterialHouse,
                NumberApartament = hostelChangeRequest.NumberApartament,
                NumberProperty = hostelChangeRequest.NumberProperty,
                Price = hostelChangeRequest.Price,
                IsActual = hostelChangeRequest.IsActual,
                DateTimePublished = hostelGet.DateTimePublished,
                SourceRealEstateObjectId = hostelGet.SourceRealEstateObjectId
            };
            db.Hostel.Update(hostel);
            await db.SaveChangesAsync();
            return await Get(hostel.Id);
        }
        public async Task<BaseResponse<HostelDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var hostel = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (hostel == null)
                return new BaseResponse<HostelDetailResponse>() { IsSuccses = false, ErrorMessage = "Общежитие не было найдено" };
            var responseEmployee =
                hostel.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)hostel.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{hostel.SourceRealEstateObjectId}");
            return new BaseResponse<HostelDetailResponse>()
            {
                IsSuccses = true,
                Data = new HostelDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    IdHostel = hostel.Id,
                    CountFloorsHouse = hostel.CountFloorsHouse,
                    LocatedFloorApartament = hostel.LocatedFloorApartament,
                    ConditionHouse = hostel.ConditionHouse,
                    CountBalcony = hostel.CountBalcony,
                    CountRooms = hostel.CountRooms,
                    DateTimePublished = hostel.DateTimePublished,
                    Description = hostel.Description,
                    District = hostel.District,
                    Employee = responseEmployee?.Data,
                    IsActual = hostel.IsActual,
                    IsCorner = hostel.IsCorner,
                    KitchenArea = hostel.KitchenArea,
                    LivingSpace = hostel.LivingSpace,
                    Locality = hostel.Locality,
                    MaterialHouse = hostel.MaterialHouse,
                    NumberApartament = hostel.NumberApartament,
                    NumberProperty = hostel.NumberProperty,
                    Price = hostel.Price,
                    Street = hostel.Street, 
                    TotalArea = hostel.TotalArea,
                    TypeSale = hostel.TypeSale
                }
            };
        }
        public async Task<BaseResponse<HostelDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var hostel = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (hostel == null)
                return new BaseResponse<HostelDetailResponse>() { IsSuccses = false, ErrorMessage = "Общежитие не было найдено" };
            Guid idSourceObject = hostel.SourceRealEstateObjectId;
            db.Hostel.Remove(hostel);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<HostelDetailResponse>() { IsSuccses = true };
        }
    }
}
