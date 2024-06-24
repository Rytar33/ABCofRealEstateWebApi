namespace ABCofRealEstate.Services.Interfaces.Services;

public interface IServiceChange<TDetailModel, TChangeModel>
    where TDetailModel : class
    where TChangeModel : class
{
    Task<BaseResponse<TDetailModel>> Change(TChangeModel apartmentChangeRequest);
}