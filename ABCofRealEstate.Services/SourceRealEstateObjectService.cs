using ABCofRealEstate.Data.Models;
using ABCofRealEstate.Data.Enums;
using ABCofRealEstate.DataBaseContext;
using ABCofRealEstate.Services.Models;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;
using ABCofRelEstate.ExportTool;
using Microsoft.EntityFrameworkCore;
using ABCofRealEstate.Services.Models.Page;
using ABCofRealEstate.Data.Models.Interfaces;

namespace ABCofRealEstate.Services
{
    public class SourceRealEstateObjectService
    {
        public async Task<BaseResponse<SourceRealEstateObjectListResponse>> GetList(SourceRealEstateObjectListRequest listRequest)
        {
            List<SourceRealEstateObjectListItem> realEstateObjectListItems = new List<SourceRealEstateObjectListItem>();
            using var db = new RealEstateDataContext();
            realEstateObjectListItems.Capacity = await db.SourceRealEstateObject.CountAsync();
            ExportJpgService exportJpgService = new ExportJpgService();
            foreach (var item in db.SourceRealEstateObject.ToArray())
            {
                IRealEstateObject realEstateObject = item.NameObject switch
                {
                    EnumObject.Apartament => await db.Apartament.FirstAsync(a => a.SourceRealEstateObjectId == item.Id),
                    EnumObject.Area => await db.Area.FirstAsync(a => a.SourceRealEstateObjectId == item.Id),
                    EnumObject.Commertion => await db.Commertion.FirstAsync(c => c.SourceRealEstateObjectId == item.Id),
                    EnumObject.Garage => await db.Garage.FirstAsync(g => g.SourceRealEstateObjectId == item.Id),
                    EnumObject.Hostel => await db.Hostel.FirstAsync(h => h.SourceRealEstateObjectId == item.Id),
                    EnumObject.House => await db.House.FirstAsync(h => h.SourceRealEstateObjectId == item.Id),
                    EnumObject.Room => await db.Room.FirstAsync(r => r.SourceRealEstateObjectId == item.Id),
                    _ => throw new ArgumentOutOfRangeException("Такого объекта не было найдено")
                };
                string? fullPathFile = exportJpgService.ExportFullPathJpg($"~/Files/Img/RealEstateObjects/{item.Id}") ??
                    exportJpgService.ExportFullPathJpg($"~/Files/Img/RealEstateObjects");
                realEstateObjectListItems.Add(new SourceRealEstateObjectListItem()
                {
                    IdSource = item.Id,
                    ImagePath = fullPathFile,
                    Price = realEstateObject.Price,
                    Locality = realEstateObject.Locality,
                    ImportantInformation = realEstateObject.DateTimePublished.ToString("dd/MM/yyyy HH:mm:ss")
                });
            }
            var realEstateObjects = realEstateObjectListItems.AsEnumerable();
            if (listRequest.TypeObject != null)
                realEstateObjects = realEstateObjects.Where(r => db.SourceRealEstateObject.FirstOrDefault(s => s.Id == r.IdSource && s.NameObject == listRequest.TypeObject) != null);
            if (listRequest.Locality != null)
                realEstateObjects = realEstateObjects.Where(r => r.Locality == listRequest.Locality);

            int countObjects = realEstateObjects.Count();

            realEstateObjects = realEstateObjects
                .Skip((listRequest.Page!.Page! - 1) * listRequest.Page!.PageSize!)
                .Take(listRequest.Page!.PageSize!);

            return new BaseResponse<SourceRealEstateObjectListResponse>()
            {
                IsSuccses = true,
                Data = new SourceRealEstateObjectListResponse()
                {
                    Items = realEstateObjects.ToList(),
                    Page = new PageResponse()
                    {
                        Page = listRequest.Page!.Page,
                        PageSize = listRequest.Page!.PageSize,
                        Count = countObjects
                    }
                }
            };
        }
        
        public async Task<BaseResponse<SourceRealEstateObject>> Add(SourceRealEstateObjectCreateRequest idsObjectCreateRequest)
        {
            using var db = new RealEstateDataContext();
            var realEstateObject = new SourceRealEstateObject()
            {
                NameObject = idsObjectCreateRequest.NameObject
            };
            await db.SourceRealEstateObject.AddAsync(realEstateObject);
            await db.SaveChangesAsync();
            return new BaseResponse<SourceRealEstateObject> { IsSuccses = true, Data = realEstateObject };
        }
        public async Task<BaseResponse<SourceRealEstateObject>> Delete(Guid id) 
        {
            ExportJpgService exportJpgService = new ExportJpgService();
            using var db = new RealEstateDataContext();
            var objectSource = await db.SourceRealEstateObject.AsNoTracking().FirstOrDefaultAsync(io => io.Id == id);
            if (objectSource == null)
                return new BaseResponse<SourceRealEstateObject> { IsSuccses = false, ErrorMessage = "Объект не был найден" };
            Guid idObject = objectSource.Id;
            db.SourceRealEstateObject.Remove(objectSource);
            await db.SaveChangesAsync();
            bool isSuccses = exportJpgService.RemovePathWithFiles($"~/Files/Img/RealEstateObjects/{idObject}");
            return isSuccses
                ? new BaseResponse<SourceRealEstateObject> { IsSuccses = true } 
                : new BaseResponse<SourceRealEstateObject> 
                {
                    IsSuccses = false,
                    ErrorMessage = "Не был удалён, т.к. этой директории нет"
                };
            
        }
    }
}
