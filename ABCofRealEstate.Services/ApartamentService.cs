using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;
using ABCofRealEstate.Services.Models.Employees;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using ABCofRealEstate.Services.Validations.Apartaments;
using ABCofRelEstate.ExportTool;
using Microsoft.EntityFrameworkCore;

namespace ABCofRealEstate.Services
{
    public class ApartamentService
    {
        public async Task<BaseResponse<ApartamentDetailResponse>> Create(ApartamentCreateRequest apartamentCreateRequest)
        {
            var resultValidation = apartamentCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (apartamentCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Apartament
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<ApartamentDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var apartament = new Apartament()
            {
                DateTimePublished = DateTime.Now,
                CountFloorsHouse = apartamentCreateRequest.CountFloorsHouse,
                ConditionHouse = apartamentCreateRequest.ConditionHouse,
                CountBalcony = apartamentCreateRequest.CountBalcony,
                CountRooms = apartamentCreateRequest.CountRooms,
                LocatedFloorApartament = apartamentCreateRequest.LocatedFloorApartament,
                Description = apartamentCreateRequest.Description,
                EmployeeId = apartamentCreateRequest.EmployeeId,
                TypeSale = apartamentCreateRequest.TypeSale,
                District = apartamentCreateRequest.District,
                IsCorner = apartamentCreateRequest.IsCorner,
                KitchenArea = apartamentCreateRequest.KitchenArea,
                LivingSpace = apartamentCreateRequest.LivingSpace,
                TotalArea = apartamentCreateRequest.TotalArea,
                NumberApartament = apartamentCreateRequest.NumberApartament,
                NumberProperty = apartamentCreateRequest.NumberProperty,
                Price = apartamentCreateRequest.Price,
                MaterialHouse = apartamentCreateRequest.MaterialHouse,
                Locality = apartamentCreateRequest.Locality,
                Street = apartamentCreateRequest.Street,
                SourceRealEstateObjectId = 
                resultResponse is not null
                ? resultResponse.Data!.Id 
                : apartamentCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.Apartament.AddAsync(apartament);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                apartamentCreateRequest.Files);
            return await Get(apartament.Id);
        }
        public async Task<BaseResponse<ApartamentDetailResponse>> Change(ApartamentChangeRequest apartamentChangeRequest)
        {
            var resultValidation = apartamentChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var apartamentSearch = await db.Apartament.AsNoTracking().FirstOrDefaultAsync(a => a.Id == apartamentChangeRequest.IdApartament);
            if (apartamentSearch == null)
                return new BaseResponse<ApartamentDetailResponse>() 
                {
                    IsSuccses = false,
                    ErrorMessage = "Такой квартиры не было найденно"
                };
            var apartament = new Apartament()
            {
                Id = apartamentSearch.Id,
                CountFloorsHouse = apartamentChangeRequest.CountFloorsHouse,
                ConditionHouse = apartamentChangeRequest.ConditionHouse,
                CountBalcony = apartamentChangeRequest.CountBalcony,
                CountRooms = apartamentChangeRequest.CountRooms,
                LocatedFloorApartament = apartamentChangeRequest.LocatedFloorApartament,
                Description = apartamentChangeRequest.Description,
                EmployeeId = apartamentChangeRequest.EmployeeId,
                TypeSale = apartamentChangeRequest.TypeSale,
                District = apartamentChangeRequest.District,
                IsCorner = apartamentChangeRequest.IsCorner,
                KitchenArea = apartamentChangeRequest.KitchenArea,
                LivingSpace = apartamentChangeRequest.LivingSpace,
                TotalArea = apartamentChangeRequest.TotalArea,
                NumberApartament = apartamentChangeRequest.NumberApartament,
                NumberProperty = apartamentChangeRequest.NumberProperty,
                Price = apartamentChangeRequest.Price,
                MaterialHouse = apartamentChangeRequest.MaterialHouse,
                Locality = apartamentChangeRequest.Locality,
                Street = apartamentChangeRequest.Street,
                IsActual = apartamentChangeRequest.IsActual,
                DateTimePublished = apartamentSearch.DateTimePublished,
                SourceRealEstateObjectId = apartamentSearch.SourceRealEstateObjectId,
                
            };
            db.Apartament.Update(apartament);
            await db.SaveChangesAsync();
            return await Get(apartament.Id);
        }
        public async Task<BaseResponse<ApartamentDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var apartament = await db.Apartament.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (apartament == null)
                return new BaseResponse<ApartamentDetailResponse>() { IsSuccses = false, ErrorMessage = "Квартира не была найдена" };
            BaseResponse<EmployeeDetailResponse>? resonseEmployee = null;
            if (apartament.EmployeeId != null)
                resonseEmployee = await new EmployeeService().Get(apartament.EmployeeId.Value);
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{apartament.SourceRealEstateObjectId}");
            return new BaseResponse<ApartamentDetailResponse>() 
            {
                IsSuccses = true,
                Data = new ApartamentDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    IdApartament = apartament.Id,
                    CountFloorsHouse = apartament.CountFloorsHouse,
                    Employee = resonseEmployee != null ? resonseEmployee.Data! : null,
                    LocatedFloorApartament = apartament.LocatedFloorApartament,
                    ConditionHouse = apartament.ConditionHouse,
                    CountBalcony = apartament.CountBalcony,
                    CountRooms = apartament.CountRooms,
                    DateTimePublished = apartament.DateTimePublished,
                    Description = apartament.Description,
                    District = apartament.District,
                    IsActual = apartament.IsActual,
                    TotalArea = apartament.TotalArea,
                    KitchenArea = apartament.KitchenArea,
                    LivingSpace = apartament.LivingSpace,
                    MaterialHouse = apartament.MaterialHouse,
                    NumberApartament = apartament.NumberApartament,
                    Locality = apartament.Locality,
                    IsCorner = apartament.IsCorner,
                    NumberProperty = apartament.NumberProperty,
                    Price = apartament.Price,
                    Street = apartament.Street,
                    TypeSale = apartament.TypeSale
                }
            };
        }
        public async Task<BaseResponse<ApartamentDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var apartament = await db.Apartament.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (apartament == null)
                return new BaseResponse<ApartamentDetailResponse>() { IsSuccses = false, ErrorMessage = "Квартира не была найдена" };
            Guid idSourceObject = apartament.SourceRealEstateObjectId;
            db.Apartament.Remove(apartament);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<ApartamentDetailResponse>() { IsSuccses = true };
        }
    }
}