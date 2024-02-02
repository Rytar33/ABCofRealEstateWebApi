namespace ABCofRealEstate.Services.Models
{
    public class BaseResponse<TData>
    {
        public bool IsSuccses { get; set; }
        public string? ErrorMessage { get; set; }
        public TData? Data { get; set; }
    }
}
