using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Commertions;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Commertions;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class CommertionService
    {
        public async Task<BaseResponse> Create(CommertionCreateRequest commertionCreateRequest)
        {
            var resultValidation = commertionCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Commertion.AddAsync(
                new Commertion()
                {

                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(CommertionChangeRequest commertionChangeRequest)
        {
            var resultValidation = commertionChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public CommertionDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var commertion = db.Commertion.FirstOrDefaultAsync(c => c.IdCommertion == id);
            if (commertion == null)
                return new CommertionDetailResponse() { IsSuccses = false, ErrorMessage = "Объект под комерцию не был найден" };
            return new CommertionDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var commertion = db.Commertion.FirstOrDefaultAsync(c => c.IdCommertion == id);
            if (commertion == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Объект под комерцию не был найден" };
            db.Commertion.Remove(await commertion);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
