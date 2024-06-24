using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IHostelService :
    IServiceCreate<HostelDetailResponse, HostelCreateRequest>,
    IServiceGet<HostelDetailResponse>,
    IServiceChange<HostelDetailResponse, HostelChangeRequest>,
    IServiceDelete<HostelDetailResponse>
{ }