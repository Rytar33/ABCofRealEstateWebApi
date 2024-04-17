using ABCofRealEstate.Services.Models.Garages;

namespace ABCofRealEstate.Services.Interfaces;

public interface IGarageService : 
    IServiceCreate<GarageDetailResponse, GarageCreateRequest>, 
    IServiceGet<GarageDetailResponse>,
    IServiceChange<GarageDetailResponse, GarageChangeRequest>,
    IServiceDelete<GarageDetailResponse>
{}