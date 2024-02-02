using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Garages;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Garages;
using ABCofRealEstate.Data.Enums;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services
{
    public class GarageService
    {
        public async Task<BaseResponse<GarageDetailResponse>> Create(GarageCreateRequest garageCreateRequest)
        {
            var resultValidation = garageCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (garageCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Garage
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<GarageDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var garage = new Garage()
            {
                District = garageCreateRequest.District,
                Description = garageCreateRequest.Description,
                EmployeeId = garageCreateRequest.IdEmployee,
                Locality = garageCreateRequest.Locality,
                Price = garageCreateRequest.Price,
                Street = garageCreateRequest.Street,
                DateTimePublished = DateTime.Now,
                TypeSale = garageCreateRequest.TypeSale,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : garageCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.Garage.AddAsync(garage);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                garageCreateRequest.Files);
            return await Get(garage.Id);
        }
        public async Task<BaseResponse<GarageDetailResponse>> Change(GarageChangeRequest garageChangeRequest)
        {
            var resultValidation = garageChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var garageGet = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == garageChangeRequest.IdGarage);
            if(garageGet == null)
                return new BaseResponse<GarageDetailResponse>() 
                {
                    IsSuccses = false,
                    ErrorMessage = "Гараж не был найден"
                };
            var garage = new Garage()
            {
                Id = garageChangeRequest.IdGarage,
                District = garageChangeRequest.District,
                Description = garageChangeRequest.Description,
                EmployeeId = garageChangeRequest.IdEmployee,
                Locality = garageChangeRequest.Locality,
                Price = garageChangeRequest.Price,
                Street = garageChangeRequest.Street,
                IsActual = garageChangeRequest.IsActual,
                TypeSale = garageChangeRequest.TypeSale,
                DateTimePublished = garageGet.DateTimePublished,
                SourceRealEstateObjectId = garageGet.SourceRealEstateObjectId
            };
            db.Garage.Update(garage);
            await db.SaveChangesAsync();
            return await Get(garage.Id);
        }
        public async Task<BaseResponse<GarageDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var garage = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (garage == null)
                return new BaseResponse<GarageDetailResponse>() { IsSuccses = false, ErrorMessage = "Гараж не был найден" };
            var responseEmployee =
                garage.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)garage.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{garage.SourceRealEstateObjectId}");
            return new BaseResponse<GarageDetailResponse>()
            {
                IsSuccses = true,
                Data = new GarageDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    IdGarage = garage.Id,
                    Employee = responseEmployee?.Data,
                    DateTimePublished = garage.DateTimePublished,
                    Description = garage.Description,
                    District = garage.District,
                    IsActual = garage.IsActual,
                    Locality = garage.Locality,
                    Price = garage.Price,
                    Street = garage.Street,
                    TypeSale = garage.TypeSale
                }
            };
        }
        public async Task<BaseResponse<GarageDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var garage = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (garage == null)
                return new BaseResponse<GarageDetailResponse>() { IsSuccses = false, ErrorMessage = "Гараж не был найден" };
            Guid idSourceObject = garage.SourceRealEstateObjectId;
            db.Garage.Remove(garage);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<GarageDetailResponse>() { IsSuccses = true };
        }
    }
}
