using ABCofRealEstate.Services.Models.Comertions;

namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IComertionService :
    IServiceCreate<ComertionDetailResponse, ComertionCreateRequest>,
    IServiceGet<ComertionDetailResponse>,
    IServiceChange<ComertionDetailResponse, ComertionChangeRequest>,
    IServiceDelete<ComertionDetailResponse>
{ }