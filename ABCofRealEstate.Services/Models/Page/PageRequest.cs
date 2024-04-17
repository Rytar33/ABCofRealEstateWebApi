namespace ABCofRealEstate.Services.Models.Page
{
    public class PageRequest
    {
        public PageRequest(int? page = null, int? pageSize = null)
        {
            Page = page ?? 1;
            PageSize = pageSize ?? 10;
        }
        public int Page { get; init; }
        public int PageSize { get; init; }
    }
}