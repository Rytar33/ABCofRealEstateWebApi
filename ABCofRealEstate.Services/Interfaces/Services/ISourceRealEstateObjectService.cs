using ABCofRealEstate.Data.Models.Entities;
using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services.Interfaces.Services;

public interface ISourceRealEstateObjectService :
    IServiceCreate<SourceRealEstateObject, SourceRealEstateObjectCreateRequest>,
    IServiceDelete<SourceRealEstateObject>,
    IServiceGetPage<SourceRealEstateObjectListRequest, SourceRealEstateObjectListResponse>
{ }