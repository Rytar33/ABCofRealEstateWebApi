namespace ABCofRealEstate.Services.Interfaces;

public interface IServiceCreate<TDetailModel, TCreateModel> 
    where TDetailModel : class
    where TCreateModel : class
{
    Task<BaseResponse<TDetailModel>> Create(TCreateModel createRequest);
}