using ABCofRealEstate.Services.Models.Areas;
using ABCofRealEstate.Services.Validations.Areas;

namespace ABCofRealEstate.Services
{
    public class AreaService : IAreaService
    {
        public async Task<BaseResponse<AreaDetailResponse>> Create(AreaCreateRequest areaCreateRequest)
        {
            var resultValidation = areaCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Area));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<AreaDetailResponse>
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var area = new Area(
                areaCreateRequest.District,
                areaCreateRequest.Street,
                areaCreateRequest.Description,
                areaCreateRequest.Price,
                areaCreateRequest.EmployeeId,
                areaCreateRequest.TypeSale,
                areaCreateRequest.Locality,
                areaCreateRequest.LandArea,
                areaCreateRequest.Latitude,
                areaCreateRequest.Longitude)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };

            await using var db = new RealEstateDataContext();
            await db.Area.AddAsync(area);
            await db.SaveChangesAsync();
            await ExportImageService.ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse.Data!.Id}",
                areaCreateRequest.Files);
            return await Get(area.Id);
        }
        public async Task<BaseResponse<AreaDetailResponse>> Change(AreaChangeRequest areaChangeRequest)
        {
            var resultValidation = areaChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            await using var db = new RealEstateDataContext();
            var areaGet = await db.Area.AsNoTracking().FirstOrDefaultAsync(a => a.Id == areaChangeRequest.Id);
            if (areaGet == null)
                return new BaseResponse<AreaDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Участок не был найден"
                };
            var area = new Area(
                areaChangeRequest.District,
                areaChangeRequest.Street,
                areaChangeRequest.Description,
                areaChangeRequest.Price,
                areaChangeRequest.EmployeeId,
                areaChangeRequest.TypeSale,
                areaChangeRequest.Locality,
                areaChangeRequest.LandArea,
                areaChangeRequest.Latitude,
                areaChangeRequest.Longitude)
            {
                Id = areaChangeRequest.Id,
                IsActual = areaChangeRequest.IsActual,
                DateTimePublished = areaGet.DateTimePublished,
                SourceRealEstateObjectId = areaGet.SourceRealEstateObjectId
            };
            db.Area.Update(area);
            await db.SaveChangesAsync();
            return await Get(area.Id);
        }
        public async Task<BaseResponse<AreaDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var area = await db.Area
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (area == null)
                return new BaseResponse<AreaDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Участок не был найден"
                };
            var responseEmployee = 
                area.EmployeeId is not null 
                ? await new EmployeeService().Get((Guid)area.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{area.SourceRealEstateObjectId}");
            return new BaseResponse<AreaDetailResponse>
            {
                IsSuccess = true,
                Data = new AreaDetailResponse(
                    fullPathsImage,
                    area.Id,
                    area.District,
                    area.Street,
                    area.Description,
                    area.Price,
                    responseEmployee?.Data,
                    area.TypeSale,
                    area.Locality,
                    area.LandArea,
                    area.Latitude,
                    area.Longitude,
                    area.IsActual,
                    area.DateTimePublished)
            };
        }
        public async Task<BaseResponse<AreaDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var area = await db.Area
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (area == null)
                return new BaseResponse<AreaDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Участок не был найден"
                };
            var idSource = area.SourceRealEstateObjectId;
            db.Area.Remove(area);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSource);
            return new BaseResponse<AreaDetailResponse> { IsSuccess = true };
        }
    }
}
