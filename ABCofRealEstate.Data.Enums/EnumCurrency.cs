using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumCurrency
    {
        Usd = 1,
        Euro = 2,
        RubPMR = 3
    }
}
