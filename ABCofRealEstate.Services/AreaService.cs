using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Models.Areas;
using ABCofRealEstate.Services.Validations.Areas;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class AreaService
    {
        public async Task<BaseResponse> Create(AreaCreateRequest areaCreateRequest)
        {
            var resultValidation = areaCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Area.AddAsync(
                new Area()
                {

                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(AreaChangeRequest areaChangeRequest)
        {
            var resultValidation = areaChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public AreaDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var area = db.Area.FirstOrDefaultAsync(a => a.IdArea == id);
            if (area == null)
                return new AreaDetailResponse() { IsSuccses = false, ErrorMessage = "Участок не был найден" };
            return new AreaDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var area = db.Area.FirstOrDefaultAsync(a => a.IdArea == id);
            if (area == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Участок не был найден" };
            db.Area.Remove(await area);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
