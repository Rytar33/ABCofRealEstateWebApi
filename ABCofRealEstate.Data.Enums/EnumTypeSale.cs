using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumTypeSale
    {
        Rental = 1,
        Sale = 2
    }
}
