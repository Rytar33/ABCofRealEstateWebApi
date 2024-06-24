namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IServiceDelete<TDetailModel>
    where TDetailModel : class
{
    Task<BaseResponse<TDetailModel>> Delete(Guid id);
}