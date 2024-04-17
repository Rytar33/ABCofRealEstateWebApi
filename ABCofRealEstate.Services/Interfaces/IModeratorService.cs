using ABCofRealEstate.Services.Models.Moderators;

namespace ABCofRealEstate.Services.Interfaces;

public interface IModeratorService :
    IServiceCreate<ModeratorDetailResponse, ModeratorCreateRequest>,
    IServiceGet<ModeratorDetailResponse>,
    IServiceChange<ModeratorDetailResponse, ModeratorChangeRequest>,
    IServiceDelete<ModeratorDetailResponse>,
    IServiceGetPage<ModeratorListRequest, ModeratorListResponse>
{
    Task<BaseResponse<ModeratorLogInResponse>> LogIn(ModeratorAuthenticationRequest moderatorAuthenticationRequest);
}