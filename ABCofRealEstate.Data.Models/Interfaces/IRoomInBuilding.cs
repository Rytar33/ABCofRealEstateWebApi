namespace ABCofRealEstate.Data.Models.Interfaces
{
    public interface IRoomInBuilding : IBuilding, IResidentialProperty
    {
        /// <summary> Номер квартиры </summary>
        public string NumberApartament { get; set; }
        /// <summary> Количество балконов </summary>
        public short CountBalcony { get; set; }
    }
}
