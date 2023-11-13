namespace ABCofRealEstate.Data.Models
{
    public class Garage : IRealEstateObject
    {
        public string District { get; set; }
        public string Street { get; set; }
        public string? URLImgs { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int? IdEmployee { get; set; }
        public Employee Employee { get; set; }

    }
}
