using ABCofRealEstate.Data.Enums;

namespace ABCofRealEstate.Services.Models.IdsObjects
{
    public class IdsObjectCreateRequest
    {
        public int IdSource { get; set; }
        public EnumObject NameObject { get; set; }
    }
}
