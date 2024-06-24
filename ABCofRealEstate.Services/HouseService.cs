using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services
{
    public class HouseService : IHouseService
    {
        public async Task<BaseResponse<HouseDetailResponse>> Create(HouseCreateRequest houseCreateRequest)
        {
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.House));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<HouseDetailResponse>
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var house = new House(
                houseCreateRequest.CountRooms,
                houseCreateRequest.District,
                houseCreateRequest.Street,
                houseCreateRequest.NumberProperty,
                houseCreateRequest.ConditionHouse,
                houseCreateRequest.LivingSpace,
                houseCreateRequest.TotalArea,
                houseCreateRequest.KitchenArea,
                houseCreateRequest.CountFloorsHouse,
                houseCreateRequest.LocatedFloorApartment,
                houseCreateRequest.IsCorner,
                houseCreateRequest.MaterialHouse,
                houseCreateRequest.Description,
                houseCreateRequest.Price,
                houseCreateRequest.EmployeeId,
                houseCreateRequest.TypeSale,
                houseCreateRequest.Locality,
                houseCreateRequest.GardenSot,
                houseCreateRequest.Area,
                houseCreateRequest.Latitude,
                houseCreateRequest.Longitude)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.House.AddAsync(house);
            await db.SaveChangesAsync();
            await ExportImageService
                .ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse!.Data!.Id}",
                houseCreateRequest.Files);
            return await Get(house.Id);
        }
        public async Task<BaseResponse<HouseDetailResponse>> Change(HouseChangeRequest houseChangeRequest)
        {
            await using var db = new RealEstateDataContext();
            var houseGet = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == houseChangeRequest.Id);
            if (houseGet == null)
                return new BaseResponse<HouseDetailResponse>()
                {
                    IsSuccess = false,
                    ErrorMessage = "Такого дома не было найдено"
                };
            var house = new House(
                houseChangeRequest.CountRooms,
                houseChangeRequest.District,
                houseChangeRequest.Street,
                houseChangeRequest.NumberProperty,
                houseChangeRequest.ConditionHouse,
                houseChangeRequest.LivingSpace,
                houseChangeRequest.TotalArea,
                houseChangeRequest.KitchenArea,
                houseChangeRequest.CountFloorsHouse,
                houseChangeRequest.LocatedFloorApartment,
                houseChangeRequest.IsCorner,
                houseChangeRequest.MaterialHouse,
                houseChangeRequest.Description,
                houseChangeRequest.Price,
                houseChangeRequest.EmployeeId,
                houseChangeRequest.TypeSale,
                houseChangeRequest.Locality,
                houseChangeRequest.GardenSot,
                houseChangeRequest.Area,
                houseChangeRequest.Latitude,
                houseChangeRequest.Longitude)
            {
                Id = houseChangeRequest.Id,
                IsActual = houseChangeRequest.IsActual,
                DateTimePublished = houseGet.DateTimePublished,
                SourceRealEstateObjectId = houseGet.SourceRealEstateObjectId
            };
            db.House.Update(house);
            await db.SaveChangesAsync();
            return await Get(house.Id);
        }
        public async Task<BaseResponse<HouseDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var house = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return new BaseResponse<HouseDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Дом не был найден"
                };
            var responseEmployee =
               house.EmployeeId is not null
               ? await new EmployeeService().Get((Guid)house.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{house.SourceRealEstateObjectId}");
            return new BaseResponse<HouseDetailResponse>
            {
                IsSuccess = true,
                Data = new HouseDetailResponse(
                    house.Id,
                    house.CountRooms,
                    house.District,
                    house.Street,
                    house.NumberProperty,
                    house.ConditionHouse,
                    house.LivingSpace,
                    house.TotalArea,
                    house.KitchenArea,
                    house.IsCorner,
                    house.CountFloorsHouse,
                    house.LocatedFloorApartment,
                    house.MaterialHouse,
                    house.Description,
                    house.Price,
                    responseEmployee?.Data,
                    house.TypeSale,
                    house.Locality,
                    house.GardenSot,
                    house.Area,
                    house.Latitude,
                    house.Longitude,
                    house.IsActual,
                    house.DateTimePublished,
                    fullPathsImage)
            };
        }
        public async Task<BaseResponse<HouseDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var house = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return new BaseResponse<HouseDetailResponse> 
                    { 
                        IsSuccess = false,
                        ErrorMessage = "Дом не был найден"
                    };
            var idSourceObject = house.SourceRealEstateObjectId;
            db.House.Remove(house);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<HouseDetailResponse> { IsSuccess = true };
        }
    }
}
