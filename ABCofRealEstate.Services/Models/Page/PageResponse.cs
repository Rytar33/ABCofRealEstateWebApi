namespace ABCofRealEstate.Services.Models.Page
{
    public class PageResponse
    {
        public PageResponse(int page, int pageSize, int count)
        {
            Page = page;
            PageSize = pageSize;
            Count = count;
        }
        public int Page { get; init; }
        public int PageSize { get; init; }
        public int Count { get; init; }
    }
}
