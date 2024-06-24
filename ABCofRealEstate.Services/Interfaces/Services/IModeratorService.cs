using ABCofRealEstate.Services.Models.Moderators;

namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IModeratorService :
    IServiceCreate<ModeratorDetailResponse, ModeratorCreateRequest>,
    IServiceGet<ModeratorDetailResponse>,
    IServiceChange<ModeratorDetailResponse, ModeratorChangeRequest>,
    IServiceDelete<ModeratorDetailResponse>,
    IServiceGetPage<ModeratorListRequest, ModeratorListResponse>
{
    Task<BaseResponse<ModeratorLogInResponse>> LogIn(ModeratorAuthenticationRequest moderatorAuthenticationRequest);
}