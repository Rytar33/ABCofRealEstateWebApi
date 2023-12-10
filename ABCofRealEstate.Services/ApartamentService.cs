using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.Apartaments;
using Microsoft.EntityFrameworkCore;

namespace ABCofRealEstate.Services
{
    public class ApartamentService
    {
        public async Task<BaseResponse> Create(ApartamentCreateRequest apartamentCreateRequest)
        {
            using var db = new RealEstateDataContext();

            await db.Apartament.AddAsync(
                new Apartament() 
                {
                    
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(ApartamentChangeRequest apartamentChangeRequest)
        {
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
    }
}
