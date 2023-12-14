namespace ABCofRealEstate.Services.Models.Images
{
    public class ImageCreateRequest
    {
        public string? FileName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public byte[] DataImg { get; set; }
    }
}
