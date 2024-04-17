using ABCofRealEstate.Services.Models.Houses;

namespace ABCofRealEstate.Services.Interfaces;

public interface IHouseService : 
    IServiceCreate<HouseDetailResponse, HouseCreateRequest>, 
    IServiceGet<HouseDetailResponse>,
    IServiceChange<HouseDetailResponse, HouseChangeRequest>,
    IServiceDelete<HouseDetailResponse>
{}