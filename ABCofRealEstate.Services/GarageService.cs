using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Garages;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Garages;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class GarageService
    {
        public async Task<BaseResponse> Create(GarageCreateRequest garageCreateRequest)
        {
            var resultValidation = garageCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Garage.AddAsync(
                new Garage()
                {
                    District = garageCreateRequest.District,
                    Description = garageCreateRequest.Description,
                    IdEmployee = garageCreateRequest.IdEmployee,
                    Locality = garageCreateRequest.Locality,
                    IdsImg = garageCreateRequest.IdsImg,
                    Price = garageCreateRequest.Price,
                    Street = garageCreateRequest.Street,
                    DateTimePublished = DateTime.Now
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(GarageChangeRequest garageChangeRequest)
        {
            var resultValidation = garageChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public GarageDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var garage = db.Garage.FirstOrDefaultAsync(g => g.IdGarage == id);
            if (garage == null)
                return new GarageDetailResponse() { IsSuccses = false, ErrorMessage = "Гараж не был найден" };
            return new GarageDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var garage = db.Garage.FirstOrDefaultAsync(g => g.IdGarage == id);
            if (garage == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Гараж не был найден" };
            db.Garage.Remove(await garage);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
