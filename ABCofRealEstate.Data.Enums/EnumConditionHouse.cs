using System.Text.Json.Serialization;

namespace ABCofRealEstate.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumConditionHouse
    {
        NeedsRenovation = 1, // требует ремонта
        Residential = 2, // жилой
        GrayVariant = 3, // серый вариант
        WhiteVariant = 4, // белый вариант
        EuroRenovation = 5, // евроремонт
        Redecorating = 6, // косметический ремонт
        Unfinished = 7 // недостроенный
    }
}
