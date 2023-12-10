using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Models.Images;
using ABCofRealEstate.Services.Validations.Images;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class ImageService
    {
        public async Task<BaseResponse> Create(ImageCreateRequest imageCreateRequest)
        {
            var resultValidation = imageCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Image.AddAsync(
                new Image()
                {

                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(ImageChangeRequest imageChangeRequest)
        {
            var resultValidation = imageChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public ImageDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var image = db.Image.FirstOrDefaultAsync(i => i.IdImg == id);
            if (image == null)
                return new ImageDetailResponse() { IsSuccses = false, ErrorMessage = "Изображение не было найдено" };
            return new ImageDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var image = db.Image.FirstOrDefaultAsync(i => i.IdImg == id);
            if (image == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Изображение не было найдено" };
            db.Image.Remove(await image);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
