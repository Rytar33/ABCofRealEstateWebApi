using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Hostels;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Hostels;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class HostelService
    {
        public async Task<BaseResponse> Create(HostelCreateRequest hostelCreateRequest)
        {
            var resultValidation = hostelCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Hostel.AddAsync(
                new Hostel()
                {
                    CountRooms = hostelCreateRequest.CountRooms,
                    CountFloorsHouse = hostelCreateRequest.CountFloorsHouse,
                    LocatedFloorApartament = hostelCreateRequest.LocatedFloorApartament,
                    ConditionHouse = hostelCreateRequest.ConditionHouse,
                    Description = hostelCreateRequest.Description,
                    CountBalcony = hostelCreateRequest.CountBalcony,
                    District = hostelCreateRequest.District,
                    Street = hostelCreateRequest.Street,
                    IdEmployee = hostelCreateRequest.IdEmployee,
                    IdsImg = hostelCreateRequest.IdsImg,
                    TypeSale = hostelCreateRequest.TypeSale,
                    TotalArea = hostelCreateRequest.TotalArea,
                    IsCorner = hostelCreateRequest.IsCorner,
                    KitchenArea = hostelCreateRequest.KitchenArea,
                    LivingSpace = hostelCreateRequest.LivingSpace,
                    Locality = hostelCreateRequest.Locality,
                    MaterialHouse = hostelCreateRequest.MaterialHouse,
                    NumberApartament = hostelCreateRequest.NumberApartament,
                    NumberProperty = hostelCreateRequest.NumberProperty,
                    Price = hostelCreateRequest.Price,
                    DateTimePublished = DateTime.Now
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(HostelChangeRequest hostelChangeRequest)
        {
            var resultValidation = hostelChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public HostelDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var hostel = db.Hostel.FirstOrDefaultAsync(h => h.IdHostel == id);
            if (hostel == null)
                return new HostelDetailResponse() { IsSuccses = false, ErrorMessage = "Общежитие не было найдено" };
            return new HostelDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var hostel = db.Hostel.FirstOrDefaultAsync(h => h.IdHostel == id);
            if (hostel == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Общежитие не было найдено" };
            db.Hostel.Remove(await hostel);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
