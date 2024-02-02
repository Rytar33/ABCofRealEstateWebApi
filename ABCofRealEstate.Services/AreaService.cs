using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Models.Areas;
using ABCofRealEstate.Services.Validations.Areas;
using ABCofRealEstate.Data.Enums;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services
{
    public class AreaService
    {
        public async Task<BaseResponse<AreaDetailResponse>> Create(AreaCreateRequest areaCreateRequest)
        {
            var resultValidation = areaCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (areaCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.Area
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<AreaDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var area = new Area()
            {
                Street = areaCreateRequest.Street,
                District = areaCreateRequest.District,
                EmployeeId = areaCreateRequest.EmployeeId,
                Description = areaCreateRequest.Description,
                LandArea = areaCreateRequest.LandArea,
                Locality = areaCreateRequest.Locality,
                Price = areaCreateRequest.Price,
                DateTimePublished = DateTime.Now,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : areaCreateRequest.SourceRealEstateObjectId!.Value
            };

            using var db = new RealEstateDataContext();
            await db.Area.AddAsync(area);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                areaCreateRequest.Files);
            return await Get(area.Id);
        }
        public async Task<BaseResponse<AreaDetailResponse>> Change(AreaChangeRequest areaChangeRequest)
        {
            var resultValidation = areaChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var areaGet = await db.Area.AsNoTracking().FirstOrDefaultAsync(a => a.Id == areaChangeRequest.IdArea);
            if (areaGet == null)
                return new BaseResponse<AreaDetailResponse>()
                {
                    IsSuccses = false,
                    ErrorMessage = "Участок не был найден"
                };
            var area = new Area()
            {
                Id = areaChangeRequest.IdArea,
                Street = areaChangeRequest.Street,
                District = areaChangeRequest.District,
                EmployeeId = areaChangeRequest.EmployeeId,
                Description = areaChangeRequest.Description,
                LandArea = areaChangeRequest.LandArea,
                Locality = areaChangeRequest.Locality,
                Price = areaChangeRequest.Price,
                IsActual = areaChangeRequest.IsActual,
                TypeSale = areaChangeRequest.TypeSale,
                DateTimePublished = areaGet.DateTimePublished,
                SourceRealEstateObjectId = areaGet.SourceRealEstateObjectId
            };
            db.Area.Update(area);
            await db.SaveChangesAsync();
            return await Get(area.Id);
        }
        public async Task<BaseResponse<AreaDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var area = await db.Area.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (area == null)
                return new BaseResponse<AreaDetailResponse>() { IsSuccses = false, ErrorMessage = "Участок не был найден" };
            var responseEmployee = 
                area.EmployeeId is not null 
                ? await new EmployeeService().Get((Guid)area.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{area.SourceRealEstateObjectId}");
            return new BaseResponse<AreaDetailResponse>()
            {
                IsSuccses = true,
                Data = new AreaDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    IdArea = area.Id,
                    DateTimePublished = area.DateTimePublished,
                    Description = area.Description,
                    District = area.District,
                    Employee = responseEmployee?.Data,
                    IsActual = area.IsActual,
                    LandArea = area.LandArea,
                    Locality = area.Locality,
                    Price = area.Price,
                    Street = area.Street
                }
            };
        }
        public async Task<BaseResponse<AreaDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var area = await db.Area.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
            if (area == null)
                return new BaseResponse<AreaDetailResponse>() { IsSuccses = false, ErrorMessage = "Участок не был найден" };
            var idSource = area.SourceRealEstateObjectId;
            db.Area.Remove(area);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSource);
            return new BaseResponse<AreaDetailResponse>() { IsSuccses = true };
        }
    }
}
