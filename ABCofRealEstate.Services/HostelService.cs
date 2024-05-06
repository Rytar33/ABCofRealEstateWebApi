using ABCofRealEstate.Services.Models.Hostels;
using ABCofRealEstate.Services.Validations.Hostels;

namespace ABCofRealEstate.Services
{
    public class HostelService : IHostelService
    {
        public async Task<BaseResponse<HostelDetailResponse>> Create(HostelCreateRequest hostelCreateRequest)
        {
            var resultValidation = hostelCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Hostel));
            if (resultResponse.IsSuccess == false)
                return new BaseResponse<HostelDetailResponse>
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var hostel = new Hostel(
                hostelCreateRequest.CountRooms,
                hostelCreateRequest.District,
                hostelCreateRequest.Street,
                hostelCreateRequest.NumberApartment,
                hostelCreateRequest.NumberProperty,
                hostelCreateRequest.ConditionHouse,
                hostelCreateRequest.LivingSpace,
                hostelCreateRequest.TotalArea,
                hostelCreateRequest.KitchenArea,
                hostelCreateRequest.IsCorner,
                hostelCreateRequest.CountFloorsHouse,
                hostelCreateRequest.LocatedFloorApartment,
                hostelCreateRequest.CountBalcony,
                hostelCreateRequest.MaterialHouse,
                hostelCreateRequest.Description,
                hostelCreateRequest.Price,
                hostelCreateRequest.EmployeeId,
                hostelCreateRequest.TypeSale,
                hostelCreateRequest.Locality,
                hostelCreateRequest.Latitude,
                hostelCreateRequest.Longitude)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.Hostel.AddAsync(hostel);
            await db.SaveChangesAsync();
            await ExportImageService
                .ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse.Data!.Id}",
                hostelCreateRequest.Files);
            return await Get(hostel.Id);
        }
        public async Task<BaseResponse<HostelDetailResponse>> Change(HostelChangeRequest hostelChangeRequest)
        {
            var resultValidation = hostelChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            await using var db = new RealEstateDataContext();
            var hostelGet = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == hostelChangeRequest.Id);
            if(hostelGet == null)
                return new BaseResponse<HostelDetailResponse>() 
                {
                    IsSuccess = false,
                    ErrorMessage = "Такой общаги не было найденно"
                };
            var hostel = new Hostel(
                hostelChangeRequest.CountRooms,
                hostelChangeRequest.District,
                hostelChangeRequest.Street,
                hostelChangeRequest.NumberApartment,
                hostelChangeRequest.NumberProperty,
                hostelChangeRequest.ConditionHouse,
                hostelChangeRequest.LivingSpace,
                hostelChangeRequest.TotalArea,
                hostelChangeRequest.KitchenArea,
                hostelChangeRequest.IsCorner,
                hostelChangeRequest.CountFloorsHouse,
                hostelChangeRequest.LocatedFloorApartment,
                hostelChangeRequest.CountBalcony,
                hostelChangeRequest.MaterialHouse,
                hostelChangeRequest.Description,
                hostelChangeRequest.Price,
                hostelChangeRequest.EmployeeId,
                hostelChangeRequest.TypeSale,
                hostelChangeRequest.Locality,
                hostelChangeRequest.Latitude,
                hostelChangeRequest.Longitude)
            {
                Id = hostelChangeRequest.Id,
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
            await using var db = new RealEstateDataContext();
            var hostel = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (hostel == null)
                return new BaseResponse<HostelDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Общежитие не было найдено"
                };
            var responseEmployee =
                hostel.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)hostel.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{hostel.SourceRealEstateObjectId}");
            return new BaseResponse<HostelDetailResponse>
            {
                IsSuccess = true,
                Data = new HostelDetailResponse(
                    hostel.Id,
                    hostel.CountRooms,
                    hostel.District,
                    hostel.Street,
                    hostel.NumberApartment,
                    hostel.NumberProperty,
                    hostel.ConditionHouse,
                    hostel.LivingSpace,
                    hostel.TotalArea,
                    hostel.KitchenArea,
                    hostel.IsCorner,
                    hostel.CountFloorsHouse,
                    hostel.LocatedFloorApartment,
                    hostel.CountBalcony,
                    hostel.MaterialHouse,
                    hostel.Description,
                    hostel.Price,
                    responseEmployee?.Data,
                    hostel.TypeSale,
                    hostel.Locality,
                    hostel.Latitude,
                    hostel.Longitude,
                    hostel.IsActual,
                    hostel.DateTimePublished,
                    fullPathsImage)
            };
        }
        public async Task<BaseResponse<HostelDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var hostel = await db.Hostel.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (hostel == null)
                return new BaseResponse<HostelDetailResponse> 
                    { 
                        IsSuccess = false,
                        ErrorMessage = "Общежитие не было найдено"
                    };
            var idSourceObject = hostel.SourceRealEstateObjectId;
            db.Hostel.Remove(hostel);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<HostelDetailResponse> { IsSuccess = true };
        }
    }
}
