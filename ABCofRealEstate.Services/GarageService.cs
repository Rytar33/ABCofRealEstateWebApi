using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Services
{
    public class GarageService : IGarageService
    {
        public async Task<BaseResponse<GarageDetailResponse>> Create(GarageCreateRequest garageCreateRequest)
        {
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Garage));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<GarageDetailResponse>()
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var garage = new Garage(
                garageCreateRequest.District,
                garageCreateRequest.Street, 
                garageCreateRequest.Description, 
                garageCreateRequest.Price, 
                garageCreateRequest.EmployeeId, 
                garageCreateRequest.TypeSale, 
                garageCreateRequest.Locality,
                garageCreateRequest.GarageCapacity,
                garageCreateRequest.HaveBasement,
                garageCreateRequest.Latitude,
                garageCreateRequest.Longitude)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.Garage.AddAsync(garage);
            await db.SaveChangesAsync();
            await ExportImageService
                .ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse!.Data!.Id}",
                garageCreateRequest.Files);
            return await Get(garage.Id);
        }
        public async Task<BaseResponse<GarageDetailResponse>> Change(GarageChangeRequest garageChangeRequest)
        {
            await using var db = new RealEstateDataContext();
            var garageGet = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == garageChangeRequest.Id);
            if(garageGet == null)
                return new BaseResponse<GarageDetailResponse>() 
                {
                    IsSuccess = false,
                    ErrorMessage = "Гараж не был найден"
                };
            var garage = new Garage(
                garageChangeRequest.District,
                garageChangeRequest.Street, 
                garageChangeRequest.Description, 
                garageChangeRequest.Price, 
                garageChangeRequest.EmployeeId, 
                garageChangeRequest.TypeSale, 
                garageChangeRequest.Locality,
                garageChangeRequest.GarageCapacity,
                garageChangeRequest.HaveBasement,
                garageChangeRequest.Latitude,
                garageChangeRequest.Longitude)
            {
                Id = garageChangeRequest.Id,
                IsActual = garageChangeRequest.IsActual,
                DateTimePublished = garageGet.DateTimePublished,
                SourceRealEstateObjectId = garageGet.SourceRealEstateObjectId
            };
            db.Garage.Update(garage);
            await db.SaveChangesAsync();
            return await Get(garage.Id);
        }
        public async Task<BaseResponse<GarageDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var garage = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (garage == null)
                return new BaseResponse<GarageDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Гараж не был найден"
                };
            var responseEmployee =
                garage.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)garage.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{garage.SourceRealEstateObjectId}");
            return new BaseResponse<GarageDetailResponse>()
            {
                IsSuccess = true,
                Data = new GarageDetailResponse(
                    garage.Id,
                    garage.District,
                    garage.Street, 
                    garage.Description, 
                    garage.Price, 
                    responseEmployee?.Data, 
                    garage.TypeSale, 
                    garage.Locality,
                    garage.GarageCapacity,
                    garage.HaveBasement,
                    garage.DateTimePublished,
                    garage.IsActual,
                    garage.Latitude,
                    garage.Longitude,
                    fullPathsImage)
            };
        }
        public async Task<BaseResponse<GarageDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var garage = await db.Garage.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (garage == null)
                return new BaseResponse<GarageDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Гараж не был найден"
                };
            var idSourceObject = garage.SourceRealEstateObjectId;
            db.Garage.Remove(garage);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<GarageDetailResponse> { IsSuccess = true };
        }
    }
}
