namespace ABCofRealEstate.Services.Interfaces;

public interface IServiceGet<TDetailModel> 
    where TDetailModel : class
{
    Task<BaseResponse<TDetailModel>> Get(Guid id);
}