namespace ABCofRealEstate.Services.Models
{
    public class BaseResponse<TData>
    {
        public bool IsSuccess { get; init; }
        public string? ErrorMessage { get; init; }
        public TData? Data { get; init; }
    }
}
