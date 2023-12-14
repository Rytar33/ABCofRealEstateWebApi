using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Houses;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Houses;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class HouseService
    {
        public async Task<BaseResponse> Create(HouseCreateRequest houseCreateRequest)
        {
            var resultValidation = houseCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.House.AddAsync(
                new House()
                {
                    Price = houseCreateRequest.Price,
                    CountFloorsHouse = houseCreateRequest.CountFloorsHouse,
                    LocatedFloorApartament = houseCreateRequest.LocatedFloorApartament,
                    GardenSot = houseCreateRequest.GardenSot,
                    Area = houseCreateRequest.Area,
                    ConditionHouse = houseCreateRequest.ConditionHouse,
                    CountRooms = houseCreateRequest.CountRooms,
                    Description = houseCreateRequest.Description,
                    IdEmployee = houseCreateRequest.IdEmployee,
                    IdsImg = houseCreateRequest.IdsImg,
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
                    DateTimePublished = DateTime.Now
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(HouseChangeRequest houseChangeRequest)
        {
            var resultValidation = houseChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public HouseDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var house = db.House.FirstOrDefaultAsync(h => h.IdHouse == id);
            if (house == null)
                return new HouseDetailResponse() { IsSuccses = false, ErrorMessage = "Дом не был найден" };
            return new HouseDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var house = db.House.FirstOrDefaultAsync(h => h.IdHouse == id);
            if (house == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Дом не был найден" };
            db.House.Remove(await house);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
