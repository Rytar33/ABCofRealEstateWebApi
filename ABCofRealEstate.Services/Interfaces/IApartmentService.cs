using ABCofRealEstate.Services.Models.Apartments;

namespace ABCofRealEstate.Services.Interfaces;

public interface IApartmentService : 
    IServiceCreate<ApartmentDetailResponse, ApartmentCreateRequest>, 
    IServiceGet<ApartmentDetailResponse>,
    IServiceChange<ApartmentDetailResponse, ApartmentChangeRequest>,
    IServiceDelete<ApartmentDetailResponse>
{}