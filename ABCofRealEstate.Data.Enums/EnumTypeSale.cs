using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumTypeSale
    {
        [EnumMember(Value = "Аренда")]
        Rental = 1,
        [EnumMember(Value = "Продажа")]
        Sale = 2
    }
}
