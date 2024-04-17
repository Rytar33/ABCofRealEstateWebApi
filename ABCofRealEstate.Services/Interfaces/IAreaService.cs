using ABCofRealEstate.Services.Models.Areas;

namespace ABCofRealEstate.Services.Interfaces;

public interface IAreaService : 
    IServiceCreate<AreaDetailResponse, AreaCreateRequest>, 
    IServiceGet<AreaDetailResponse>,
    IServiceChange<AreaDetailResponse, AreaChangeRequest>,
    IServiceDelete<AreaDetailResponse>
{ }