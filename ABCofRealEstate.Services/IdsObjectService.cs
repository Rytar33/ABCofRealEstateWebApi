using ABCofRealEstate.Data.Models;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.IdsObjects;
using Microsoft.EntityFrameworkCore;

namespace ABCofRealEstate.Services
{
    public class IdsObjectService
    {
        public async Task<BaseResponse> Add(IdsObjectCreateRequest idsObjectCreateRequest)
        {
            using var db = new RealEstateDataContext();
            await db.IdsObject.AddAsync(
                new IdsObject()
                {
                    IdSource = idsObjectCreateRequest.IdSource,
                    NameObject = idsObjectCreateRequest.NameObject
                });
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
        public async Task<BaseResponse> Delete(int id) 
        {
            using var db = new RealEstateDataContext();
            var idObject = db.IdsObject.FirstOrDefaultAsync(io => io.IdObject == id);
            if (idObject == null)
                return new BaseResponse { IsSuccses = false, ErrorMessage = "Объект не был найден" };
            db.IdsObject.Remove(await idObject);
            await db.SaveChangesAsync();
            return new BaseResponse() { IsSuccses = true };
        }
    }
}
