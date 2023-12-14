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
                    FileName = imageCreateRequest.FileName,
                    Title = imageCreateRequest.Title,
                    DataImg = imageCreateRequest.DataImg
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> CreateImages(List<ImageCreateRequest> imagesCreateRequest)
        {
            foreach (var image in imagesCreateRequest)
            {
                var resultValidation = image.GetResultValidation();
                if (resultValidation.IsSuccses == false) return resultValidation;
            }

            using var db = new RealEstateDataContext();

            foreach (var image in imagesCreateRequest)
            {
                await db.Image.AddRangeAsync(
                    new Image()
                    {
                        FileName = image.FileName,
                        Title = image.Title,
                        DataImg = image.DataImg
                    });
            }
            
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
