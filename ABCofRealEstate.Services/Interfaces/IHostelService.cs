using ABCofRealEstate.Services.Models.Hostels;

namespace ABCofRealEstate.Services.Interfaces;

public interface IHostelService : 
    IServiceCreate<HostelDetailResponse, HostelCreateRequest>, 
    IServiceGet<HostelDetailResponse>,
    IServiceChange<HostelDetailResponse, HostelChangeRequest>,
    IServiceDelete<HostelDetailResponse>
{}