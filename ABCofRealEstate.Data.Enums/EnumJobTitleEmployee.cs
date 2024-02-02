using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumJobTitleEmployee
    {
        RealEstateAgent = 1,
        Lawyer = 2,
        Director = 3
    }
}
