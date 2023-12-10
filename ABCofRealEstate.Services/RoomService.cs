using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models.Rooms;
using ABCofRealEstate.Services.Models;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Validations.Rooms;
using ABCofRealEstate.Services.Models.Apartaments;

namespace ABCofRealEstate.Services
{
    public class RoomService
    {
        public async Task<BaseResponse> Create(RoomCreateRequest roomCreateRequest)
        {
            var resultValidation = roomCreateRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();

            await db.Room.AddAsync(
                new Room()
                {

                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Change(RoomChangeRequest roomChangeRequest)
        {
            var resultValidation = roomChangeRequest.GetResultValidation();
            if (resultValidation.IsSuccses == false) return resultValidation;

            using var db = new RealEstateDataContext();



            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public RoomDetailResponse Get(int id)
        {
            using var db = new RealEstateDataContext();
            var room = db.Room.FirstOrDefaultAsync(r => r.IdRoom == id);
            if (room == null)
                return new RoomDetailResponse() { IsSuccses = false, ErrorMessage = "Комната не была найдена" };
            return new RoomDetailResponse()
            {
                IsSuccses = true
            };
        }
        public async Task<BaseResponse> Delete(int id)
        {
            using var db = new RealEstateDataContext();
            var room = db.Room.FirstOrDefaultAsync(r => r.IdRoom == id);
            if (room == null)
                return new ApartamentDetailResponse() { IsSuccses = false, ErrorMessage = "Комната не была найдена" };
            db.Room.Remove(await room);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
