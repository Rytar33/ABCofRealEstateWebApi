using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Houses;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Houses;
using ABCofRealEstate.Data.Enums;
using ABCofRelEstate.ExportTool;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using ABCofRealEstate.Services.Models.Apartaments;
using ABCofRealEstate.Services.Models.Hostels;
using ABCofRealEstate.Services.Models.Rooms;

namespace ABCofRealEstate.Services
{
    public class HouseService
    {
        public async Task<BaseResponse<HouseDetailResponse>> Create(HouseCreateRequest houseCreateRequest)
        {
            var resultValidation = houseCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            BaseResponse<SourceRealEstateObject>? resultResponse = null;
            if (houseCreateRequest.SourceRealEstateObjectId is null)
            {
                resultResponse = await new SourceRealEstateObjectService()
                .Add(new SourceRealEstateObjectCreateRequest()
                {
                    NameObject = EnumObject.House
                });
                if (resultResponse != null && resultResponse.IsSuccses == false)
                    return new BaseResponse<HouseDetailResponse>()
                    {
                        IsSuccses = resultResponse.IsSuccses,
                        ErrorMessage = resultResponse.ErrorMessage
                    };
            }
            var house = new House()
            {
                Price = houseCreateRequest.Price,
                CountFloorsHouse = houseCreateRequest.CountFloorsHouse,
                LocatedFloorApartament = houseCreateRequest.LocatedFloorApartament,
                GardenSot = houseCreateRequest.GardenSot,
                Area = houseCreateRequest.Area,
                ConditionHouse = houseCreateRequest.ConditionHouse,
                CountRooms = houseCreateRequest.CountRooms,
                Description = houseCreateRequest.Description,
                TotalArea = houseCreateRequest.TotalArea,
                TypeSale = houseCreateRequest.TypeSale,
                IsCorner = houseCreateRequest.IsCorner,
                KitchenArea = houseCreateRequest.KitchenArea,
                LivingSpace = houseCreateRequest.LivingSpace,
                Street = houseCreateRequest.Street,
                NumberProperty = houseCreateRequest.NumberProperty,
                MaterialHouse = houseCreateRequest.MaterialHouse,
                Locality = houseCreateRequest.Locality,
                District = houseCreateRequest.District,
                DateTimePublished = DateTime.Now,
                SourceRealEstateObjectId =
                resultResponse is not null
                ? resultResponse.Data!.Id
                : houseCreateRequest.SourceRealEstateObjectId!.Value
            };
            using var db = new RealEstateDataContext();
            await db.House.AddAsync(house);
            await db.SaveChangesAsync();
            await new ExportJpgService()
                .ImportManyFile(
                $"~/Files/Img/RealEstateObjects/{resultResponse!.Data!.Id}",
                houseCreateRequest.Files);
            return await Get(house.Id);
        }
        public async Task<BaseResponse<HouseDetailResponse>> Change(HouseChangeRequest houseChangeRequest)
        {
            var resultValidation = houseChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;
            using var db = new RealEstateDataContext();
            var houseGet = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == houseChangeRequest.IdHouse);
            if (houseGet == null)
                return new BaseResponse<HouseDetailResponse>()
                {
                    IsSuccses = false,
                    ErrorMessage = "Такого дома не было найдено"
                };
            var house = new House()
            {
                Id = houseChangeRequest.IdHouse,
                Price = houseChangeRequest.Price,
                CountFloorsHouse = houseChangeRequest.CountFloorsHouse,
                LocatedFloorApartament = houseChangeRequest.LocatedFloorApartament,
                GardenSot = houseChangeRequest.GardenSot,
                Area = houseChangeRequest.Area,
                ConditionHouse = houseChangeRequest.ConditionHouse,
                CountRooms = houseChangeRequest.CountRooms,
                Description = houseChangeRequest.Description,
                TotalArea = houseChangeRequest.TotalArea,
                TypeSale = houseChangeRequest.TypeSale,
                IsCorner = houseChangeRequest.IsCorner,
                KitchenArea = houseChangeRequest.KitchenArea,
                LivingSpace = houseChangeRequest.LivingSpace,
                Street = houseChangeRequest.Street,
                NumberProperty = houseChangeRequest.NumberProperty,
                MaterialHouse = houseChangeRequest.MaterialHouse,
                Locality = houseChangeRequest.Locality,
                District = houseChangeRequest.District,
                IsActual = houseChangeRequest.IsActual,
                DateTimePublished = houseGet.DateTimePublished,
                EmployeeId = houseChangeRequest.IdEmployee,
                SourceRealEstateObjectId = houseGet.SourceRealEstateObjectId
            };
            db.House.Update(house);
            await db.SaveChangesAsync();
            return await Get(house.Id);
        }
        public async Task<BaseResponse<HouseDetailResponse>> Get(Guid id)
        {
            using var db = new RealEstateDataContext();
            var house = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return new BaseResponse<HouseDetailResponse>() { IsSuccses = false, ErrorMessage = "Дом не был найден" };
            var responseEmployee =
               house.EmployeeId is not null
               ? await new EmployeeService().Get((Guid)house.EmployeeId) : null;
            var fullPathsImage = new ExportJpgService().ExportFullPathsJpg($"~/Files/Img/RealEstateObjects/{house.SourceRealEstateObjectId}");
            return new BaseResponse<HouseDetailResponse>()
            {
                IsSuccses = true,
                Data = new HouseDetailResponse()
                {
                    FullPathsImage = fullPathsImage,
                    IdHouse = house.Id,
                    CountFloorsHouse = house.CountFloorsHouse,
                    LocatedFloorApartament = house.LocatedFloorApartament,
                    Area = house.Area,
                    ConditionHouse = house.ConditionHouse,
                    CountRooms = house.CountRooms,
                    DateTimePublished = house.DateTimePublished,
                    Description = house.Description,
                    District = house.District,
                    Employee = responseEmployee?.Data,
                    GardenSot = house.GardenSot,
                    IsActual = house.IsActual,
                    IsCorner = house.IsCorner,
                    KitchenArea = house.KitchenArea,
                    LivingSpace = house.LivingSpace,
                    Locality = house.Locality,
                    MaterialHouse = house.MaterialHouse,
                    NumberProperty = house.NumberProperty,
                    Price = house.Price,
                    Street = house.Street,
                    TotalArea = house.TotalArea,
                    TypeSale = house.TypeSale
                }
            };
        }
        public async Task<BaseResponse<HouseDetailResponse>> Delete(Guid id)
        {
            var serviceRealEstateObject = new SourceRealEstateObjectService();
            using var db = new RealEstateDataContext();
            var house = await db.House.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
                return new BaseResponse<HouseDetailResponse>() { IsSuccses = false, ErrorMessage = "Дом не был найден" };
            Guid idSourceObject = house.SourceRealEstateObjectId;
            db.House.Remove(house);
            await db.SaveChangesAsync();
            await serviceRealEstateObject.Delete(idSourceObject);
            return new BaseResponse<HouseDetailResponse>() { IsSuccses = true };
        }
    }
}
