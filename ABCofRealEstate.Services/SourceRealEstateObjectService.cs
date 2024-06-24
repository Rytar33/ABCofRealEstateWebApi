using ABCofRealEstate.Services.Models.Page;
using ABCofRealEstate.Data.Models.Interfaces;

namespace ABCofRealEstate.Services
{
    public class SourceRealEstateObjectService : ISourceRealEstateObjectService
    {
        public async Task<BaseResponse<SourceRealEstateObjectListResponse>> GetPage(SourceRealEstateObjectListRequest listRequest)
        {
            var realEstateObjectListItems = new List<SourceRealEstateObjectListItem>();
            await using var db = new RealEstateDataContext();
            realEstateObjectListItems.Capacity = await db.SourceRealEstateObject.CountAsync();
            int maxPrice = 0;
            foreach (var item in db.SourceRealEstateObject.ToArray())
            {
                IRealEstateObject? realEstateObject = item.NameObject switch
                {
                    EnumObject.Apartment => await db.Apartment.FirstOrDefaultAsync(a => a.SourceRealEstateObjectId == item.Id),
                    EnumObject.Area => await db.Area.FirstOrDefaultAsync(a => a.SourceRealEstateObjectId == item.Id),
                    EnumObject.Comertion => await db.Comertion.FirstOrDefaultAsync(c => c.SourceRealEstateObjectId == item.Id),
                    EnumObject.Garage => await db.Garage.FirstOrDefaultAsync(g => g.SourceRealEstateObjectId == item.Id),
                    EnumObject.Hostel => await db.Hostel.FirstOrDefaultAsync(h => h.SourceRealEstateObjectId == item.Id),
                    EnumObject.House => await db.House.FirstOrDefaultAsync(h => h.SourceRealEstateObjectId == item.Id),
                    EnumObject.Room => await db.Room.FirstOrDefaultAsync(r => r.SourceRealEstateObjectId == item.Id),
                    _ => throw new ArgumentOutOfRangeException("Такого объекта не было найдено")
                };
                if (realEstateObject == null)
                    continue;
                if (realEstateObject.IsActual != listRequest.IsActual)
                    continue;
                var fullPathFile = ExportImageService.ExportFullPathImage($"wwwroot/images/real-estate-objects/{item.Id}") ??
                    ExportImageService.ExportFullPathImage("wwwroot/images/real-estate-objects");
                realEstateObjectListItems.Add(new SourceRealEstateObjectListItem(
                    item.Id,
                    item.NameObject,
                    realEstateObject.Id,
                    fullPathFile,
                    realEstateObject.Locality,
                    realEstateObject.TypeSale,
                    realEstateObject.ImportantInformation,
                    realEstateObject.Price));
                if (maxPrice < realEstateObject.Price)
                    maxPrice = realEstateObject.Price;
            }
            var realEstateObjects = realEstateObjectListItems.AsEnumerable();

            if (listRequest.TypeSale != null)
                realEstateObjects = realEstateObjects.Where(r => r.TypeSale == listRequest.TypeSale);
            if (listRequest.TypeObject != null)
                realEstateObjects = realEstateObjects.Where(r => 
                    db.SourceRealEstateObject.FirstOrDefault(s => 
                        s.Id == r.IdSource && s.NameObject == listRequest.TypeObject) != null);
            if (listRequest.Locality != null)
                realEstateObjects = realEstateObjects.Where(r => 
                    r.Locality == listRequest.Locality);

            int countObjects = realEstateObjects.Count();
            
            realEstateObjects = realEstateObjects
                .Skip((listRequest.Page!.Page - 1) * listRequest.Page!.PageSize)
                .Take(listRequest.Page!.PageSize);

            return new BaseResponse<SourceRealEstateObjectListResponse>()
            {
                IsSuccess = true,
                Data = new SourceRealEstateObjectListResponse(
                    realEstateObjects.ToList(),
                    new PageResponse(
                        listRequest.Page.Page,
                        listRequest.Page.PageSize,
                        countObjects),
                    maxPrice)
            };
        }
        
        public async Task<BaseResponse<SourceRealEstateObject>> Create(SourceRealEstateObjectCreateRequest idsObjectCreateRequest)
        {
            await using var db = new RealEstateDataContext();
            var realEstateObject = new SourceRealEstateObject(idsObjectCreateRequest.NameObject);
            await db.SourceRealEstateObject.AddAsync(realEstateObject);
            await db.SaveChangesAsync();
            return new BaseResponse<SourceRealEstateObject>
            {
                IsSuccess = true,
                Data = realEstateObject
            };
        }
        public async Task<BaseResponse<SourceRealEstateObject>> Delete(Guid id) 
        {
            await using var db = new RealEstateDataContext();
            var objectSource = await db.SourceRealEstateObject
                .AsNoTracking()
                .FirstOrDefaultAsync(io => io.Id == id);
            if (objectSource == null)
                return new BaseResponse<SourceRealEstateObject>
                {
                    IsSuccess = false,
                    ErrorMessage = "Объект не был найден"
                };
            var idObject = objectSource.Id;
            db.SourceRealEstateObject.Remove(objectSource);
            await db.SaveChangesAsync();
            ExportImageService.RemovePathWithFiles($"wwwroot/images/real-estate-objects/{idObject}");
            return new BaseResponse<SourceRealEstateObject> { IsSuccess = true };
        }
    }
}
