namespace ABCofRealEstate.Services.Models.SourceRealEstateObjects
{
    public class SourceRealEstateObjectCreateRequest
    {
        public SourceRealEstateObjectCreateRequest(EnumObject nameObject) 
            => NameObject = nameObject;
        public SourceRealEstateObjectCreateRequest()
        {
            
        }
        public EnumObject NameObject { get; init; }
    }
}
