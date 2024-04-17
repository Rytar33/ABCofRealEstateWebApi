using ABCofRealEstate.Services.Models.Comertions;
using ABCofRealEstate.Services.Validations.Comertions;

namespace ABCofRealEstate.Services
{
    public class ComertionService : IComertionService
    {
        public async Task<BaseResponse<ComertionDetailResponse>> Create(ComertionCreateRequest comertionCreateRequest)
        {
            var resultValidation = comertionCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;
            var resultResponse = await new SourceRealEstateObjectService()
                .Create(new SourceRealEstateObjectCreateRequest(EnumObject.Comertion));
            if (!resultResponse.IsSuccess)
                return new BaseResponse<ComertionDetailResponse>
                {
                    IsSuccess = resultResponse.IsSuccess,
                    ErrorMessage = resultResponse.ErrorMessage
                };
            var comertion = new Comertion(
                comertionCreateRequest.CountRooms,
                comertionCreateRequest.District,
                comertionCreateRequest.Street,
                comertionCreateRequest.NumberProperty,
                comertionCreateRequest.CountFloorsHouse,
                comertionCreateRequest.LocatedFloorApartment,
                comertionCreateRequest.MaterialHouse,
                comertionCreateRequest.RoomArea,
                comertionCreateRequest.IsCorner,
                comertionCreateRequest.Description,
                comertionCreateRequest.Price,
                comertionCreateRequest.EmployeeId,
                comertionCreateRequest.TypeSale,
                comertionCreateRequest.Locality)
            {
                SourceRealEstateObjectId = resultResponse.Data!.Id
            };
            await using var db = new RealEstateDataContext();
            await db.Comertion.AddAsync(comertion);
            await db.SaveChangesAsync();
            await ExportImageService.ImportManyFile(
                $"wwwroot/images/real-estate-objects/{resultResponse.Data!.Id}",
                comertionCreateRequest.Files);
            return await Get(comertion.Id);
        }
        public async Task<BaseResponse<ComertionDetailResponse>> Change(ComertionChangeRequest comertionChangeRequest)
        {
            var resultValidation = comertionChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccess == false) return resultValidation;

            await using var db = new RealEstateDataContext();
            var comertionGet = await db.Comertion.AsNoTracking().FirstOrDefaultAsync(a => a.Id == comertionChangeRequest.Id);
            if (comertionGet == null)
                return new BaseResponse<ComertionDetailResponse>() 
                {
                    IsSuccess = false,
                    ErrorMessage = "Объект под коммерцию не был найден"
                };
            var comertion = new Comertion(
                comertionChangeRequest.CountRooms,
                comertionChangeRequest.District,
                comertionChangeRequest.Street,
                comertionChangeRequest.NumberProperty,
                comertionChangeRequest.CountFloorsHouse,
                comertionChangeRequest.LocatedFloorApartment,
                comertionChangeRequest.MaterialHouse,
                comertionChangeRequest.RoomArea,
                comertionChangeRequest.IsCorner,
                comertionChangeRequest.Description,
                comertionChangeRequest.Price,
                comertionChangeRequest.EmployeeId,
                comertionChangeRequest.TypeSale,
                comertionChangeRequest.Locality)
            {
                Id = comertionChangeRequest.Id,
                DateTimePublished = comertionGet.DateTimePublished,
                IsActual = comertionChangeRequest.IsActual,
                SourceRealEstateObjectId = comertionGet.SourceRealEstateObjectId
            };
            db.Comertion.Update(comertion);
            await db.SaveChangesAsync();
            return await Get(comertion.Id);
        }
        public async Task<BaseResponse<ComertionDetailResponse>> Get(Guid id)
        {
            await using var db = new RealEstateDataContext();
            var comertion = await db.Comertion
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (comertion == null)
                return new BaseResponse<ComertionDetailResponse>
                {
                    IsSuccess = false,
                    ErrorMessage = "Объект под комерцию не был найден"
                };
            var responseEmployee =
                comertion.EmployeeId is not null
                ? await new EmployeeService().Get((Guid)comertion.EmployeeId) : null;
            var fullPathsImage = ExportImageService.ExportFullPathsImage(
                $"wwwroot/images/real-estate-objects/{comertion.SourceRealEstateObjectId}");
            return new BaseResponse<ComertionDetailResponse>()
            {
                IsSuccess = true,
                Data = new ComertionDetailResponse(
                    fullPathsImage,
                    comertion.Id,
                    comertion.CountRooms,
                    comertion.District,
                    comertion.Street,
                    comertion.NumberProperty,
                    comertion.CountFloorsHouse,
                    comertion.LocatedFloorApartment,
                    comertion.MaterialHouse,
                    comertion.IsCorner,
                    comertion.Description,
                    comertion.Price,
                    responseEmployee?.Data,
                    comertion.RoomArea,
                    comertion.TypeSale,
                    comertion.Locality,
                    comertion.IsActual,
                    comertion.DateTimePublished)
            };
        }
        public async Task<BaseResponse<ComertionDetailResponse>> Delete(Guid id)
        {
            ISourceRealEstateObjectService serviceRealEstateObject = new SourceRealEstateObjectService();
            await using var db = new RealEstateDataContext();
            var comertion = await db.Comertion
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (comertion == null)
                return new BaseResponse<ComertionDetailResponse>
                {
                    IsSuccess = false, 
                    ErrorMessage = "Объект под комерцию не был найден"
                };
            var idSource = comertion.SourceRealEstateObjectId;
            db.Comertion.Remove(comertion);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSource);
            return new BaseResponse<ComertionDetailResponse> { IsSuccess = true };
        }
    }
}
