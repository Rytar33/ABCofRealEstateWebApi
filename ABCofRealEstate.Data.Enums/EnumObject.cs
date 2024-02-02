using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumObject
    {
        Apartament = 1,
        Area = 2,
        Commertion = 3,
        Garage = 4,
        Hostel = 5,
        House = 6,
        Room = 7
    }
}
