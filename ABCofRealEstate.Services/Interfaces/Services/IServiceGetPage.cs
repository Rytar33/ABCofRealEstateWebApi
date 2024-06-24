namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IServiceGetPage<TModelGetListRequest, TModelGetListResponse>
    where TModelGetListRequest : class
    where TModelGetListResponse : class
{
    Task<BaseResponse<TModelGetListResponse>> GetPage(TModelGetListRequest getListRequest);
}