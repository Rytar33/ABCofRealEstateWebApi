using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;
using ABCofRealEstate.Services.Models.IdsObjects;
using ABCofRealEstate.Services.Validations.Apartaments;
using Microsoft.EntityFrameworkCore;

namespace ABCofRealEstate.Services
{
    public class ApartamentService
    {
        public async Task<BaseResponse> Create(ApartamentCreateRequest apartamentCreateRequest)
        {
            var resultValidation = apartamentCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Apartament.AddAsync(
                new Apartament() 
                {
                    IdsImg = apartamentCreateRequest.IdsImg,
                    DateTimePublished = DateTime.Now,
                    CountFloorsHouse = apartamentCreateRequest.CountFloorsHouse,
                    ConditionHouse = apartamentCreateRequest.ConditionHouse,
                    CountBalcony = apartamentCreateRequest.CountBalcony,
                    CountRooms = apartamentCreateRequest.CountRooms,
                    LocatedFloorApartament = apartamentCreateRequest.LocatedFloorApartament,
                    Description = apartamentCreateRequest.Description,
                    IdEmployee = apartamentCreateRequest.IdEmployee,
                    TypeSale = apartamentCreateRequest.TypeSale,
                    District = apartamentCreateRequest.District,
                    IsCorner = apartamentCreateRequest.IsCorner,
                    KitchenArea = apartamentCreateRequest.KitchenArea,
                    LivingSpace = apartamentCreateRequest.LivingSpace,
                    TotalArea = apartamentCreateRequest.TotalArea,
                    NumberApartament = apartamentCreateRequest.NumberApartament,
                    NumberProperty = apartamentCreateRequest.NumberProperty,
                    Price = apartamentCreateRequest.Price,
                    MaterialHouse = apartamentCreateRequest.MaterialHouse,
                    Locality = apartamentCreateRequest.Locality,
                    Street = apartamentCreateRequest.Street
                });
            await db.SaveChangesAsync();

            var lastApartament = db.Apartament.Last();
            var resultResponse = await new IdsObjectService()
                .Add(new IdsObjectCreateRequest() 
                { 
                    IdSource = lastApartament.IdApartament,
                    NameObject = EnumObject.Apartament
                });

            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(ApartamentChangeRequest apartamentChangeRequest)
        {
            var resultValidation = apartamentChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public ApartamentDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var apartament = db.Apartament.FirstOrDefaultAsync(a => a.IdApartament == id);
            if (apartament == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Квартира не была найдена" };
            return new ApartamentDetailResponse() 
            {
                
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var apartament = await db.Apartament.FirstOrDefaultAsync(a => a.IdApartament == id);
            if (apartament == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Квартира не была найдена" };
            db.Apartament.Remove(apartament);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
