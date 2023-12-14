namespace ABCofRealEstate.Services.Models.Images
{
    public class ImageDetailResponse : BaseResponse
    {
        public int? IdImg { get; set; }
        public string? FileName { get; set; }
        public string? Title { get; set; }
        public byte[]? DataImg { get; set; }
    }
}
