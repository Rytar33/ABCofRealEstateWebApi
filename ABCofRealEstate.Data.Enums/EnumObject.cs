using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumObject
    {
        Apartment = 1,
        Area = 2,
        Comertion = 3,
        Garage = 4,
        Hostel = 5,
        House = 6,
        Room = 7
    }
}
