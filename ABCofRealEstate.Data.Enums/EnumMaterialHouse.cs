using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumMaterialHouse
    {
        Kotelec = 0,
        Panel = 1,

    }
}
