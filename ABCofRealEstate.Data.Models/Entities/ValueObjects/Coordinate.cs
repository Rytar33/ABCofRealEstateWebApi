namespace ABCofRealEstate.Data.Models.Entities.ValueObjects
{
    public class Coordinate : BaseValueObject
    {
        public Coordinate(decimal latitude, decimal longitude) 
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public decimal Latitude { get; private set; }

        public decimal Longitude { get; private set; }

        public void Update(
            decimal? latitude = null,
            decimal? longitude = null)
        {
            if (latitude != null)
                Latitude = latitude.Value;
            if (longitude != null)
                Longitude = longitude.Value;
        }
    }
}
