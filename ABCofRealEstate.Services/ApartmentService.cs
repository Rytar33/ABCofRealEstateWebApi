using ABCofRealEstate.Services.Models.Apartments;
using ABCofRealEstate.Services.Validations.Apartments;

namespace ABCofRealEstate.Services
{
    public class ApartmentService : IApartmentService
    {
        public async Task<BaseResponse<ApartmentDetailResponse>> Create(ApartmentCreateRequest apartmentCreateRequest)
        {
            var resultValidation = apartmentCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Apartment));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<ApartmentDetailResponse>()
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var apartment = new Apartment(
                apartmentCreateRequest.CountRooms,
                apartmentCreateRequest.District,
                apartmentCreateRequest.Street,
                apartmentCreateRequest.NumberApartment,
                apartmentCreateRequest.NumberProperty,
                apartmentCreateRequest.ConditionHouse,
                apartmentCreateRequest.LivingSpace,
                apartmentCreateRequest.TotalArea,
                apartmentCreateRequest.KitchenArea,
                apartmentCreateRequest.CountFloorsHouse,
                apartmentCreateRequest.LocatedFloorApartment,
                apartmentCreateRequest.IsCorner,
                apartmentCreateRequest.CountBalcony,
                apartmentCreateRequest.MaterialHouse,
                apartmentCreateRequest.Description,
                apartmentCreateRequest.Price,
                apartmentCreateRequest.EmployeeId,
                apartmentCreateRequest.TypeSale,
                apartmentCreateRequest.Locality)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.Apartment.AddAsync(apartment);
            await db.SaveChangesAsync();
            await ExportImageService.ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse.Data!.Id}",
                apartmentCreateRequest.Files);
            return await Get(apartment.Id);
        }
        public async Task<BaseResponse<ApartmentDetailResponse>> Change(ApartmentChangeRequest apartmentChangeRequest)
        {
            var resultValidation = apartmentChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            await using var db = new RealEstateDataContext();
            var apartmentSearch = await db.Apartment
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == apartmentChangeRequest.Id);
            if (apartmentSearch == null)
                return new BaseResponse<ApartmentDetailResponse>() 
                {
                    IsSuccess = false,
                    ErrorMessage = "Такой квартиры не было найденно"
                };
            var apartment = new Apartment(apartmentChangeRequest.CountRooms,
                apartmentChangeRequest.District,
                apartmentChangeRequest.Street,
                apartmentChangeRequest.NumberApartment,
                apartmentChangeRequest.NumberProperty,
                apartmentChangeRequest.ConditionHouse,
                apartmentChangeRequest.LivingSpace,
                apartmentChangeRequest.TotalArea,
                apartmentChangeRequest.KitchenArea,
                apartmentChangeRequest.CountFloorsHouse,
                apartmentChangeRequest.LocatedFloorApartment,
                apartmentChangeRequest.IsCorner,
                apartmentChangeRequest.CountBalcony,
                apartmentChangeRequest.MaterialHouse,
                apartmentChangeRequest.Description,
                apartmentChangeRequest.Price,
                apartmentChangeRequest.EmployeeId,
                apartmentChangeRequest.TypeSale,
                apartmentChangeRequest.Locality)
            {
                Id = apartmentSearch.Id,
                IsActual = apartmentChangeRequest.IsActual,
                DateTimePublished = apartmentSearch.DateTimePublished,
                SourceRealEstateObjectId = apartmentSearch.SourceRealEstateObjectId
            };
            db.Apartment.Update(apartment);
            await db.SaveChangesAsync();
            return await Get(apartment.Id);
        }
        public async Task<BaseResponse<ApartmentDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var apartment = await db.Apartment
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (apartment == null)
                return new BaseResponse<ApartmentDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Квартира не была найдена"
                };
            var responseEmployee = 
                apartment.EmployeeId is not null 
                    ? await new EmployeeService().Get((Guid)apartment.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{apartment.SourceRealEstateObjectId}");
            return new BaseResponse<ApartmentDetailResponse>
            {
                IsSuccess = true,
                Data = new ApartmentDetailResponse(
                    apartment.Id,
                    apartment.CountRooms,
                    apartment.District,
                    apartment.Street,
                    apartment.NumberApartment,
                    apartment.NumberProperty,
                    apartment.ConditionHouse,
                    apartment.LivingSpace,
                    apartment.TotalArea,
                    apartment.KitchenArea,
                    apartment.CountFloorsHouse,
                    apartment.LocatedFloorApartment,
                    apartment.IsCorner,
                    apartment.CountBalcony,
                    apartment.MaterialHouse,
                    apartment.Description,
                    apartment.Price,
                    responseEmployee?.Data,
                    apartment.TypeSale,
                    apartment.Locality,
                    fullPathsImage,
                    apartment.IsActual,
                    apartment.DateTimePublished)
            };
        }
        public async Task<BaseResponse<ApartmentDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var apartment = await db.Apartment
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (apartment == null)
                return new BaseResponse<ApartmentDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Квартира не была найдена"
                };
            var idSourceObject = apartment.SourceRealEstateObjectId;
            db.Apartment.Remove(apartment);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<ApartmentDetailResponse> { IsSuccess = true };
        }
    }
}