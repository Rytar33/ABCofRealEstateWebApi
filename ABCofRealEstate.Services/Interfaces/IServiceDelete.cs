namespace ABCofRealEstate.Services.Interfaces;

public interface IServiceDelete<TDetailModel> 
    where TDetailModel : class
{
    Task<BaseResponse<TDetailModel>> Delete(Guid id);
}