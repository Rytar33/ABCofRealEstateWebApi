using ABCofRealEstate.Services.Models.SourceRealEstateObjects;

namespace ABCofRealEstate.Services.Interfaces;

public interface ISourceRealEstateObjectService : 
    IServiceCreate<SourceRealEstateObject, SourceRealEstateObjectCreateRequest>,
    IServiceDelete<SourceRealEstateObject>,
    IServiceGetPage<SourceRealEstateObjectListRequest, SourceRealEstateObjectListResponse>
{}