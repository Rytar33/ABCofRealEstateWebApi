namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IServiceGet<TDetailModel>
    where TDetailModel : class
{
    Task<BaseResponse<TDetailModel>> Get(Guid id);
}