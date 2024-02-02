using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumAccessLevel
    {
        Create = 1,
        Update = 2,
        Delete = 3
    }
}