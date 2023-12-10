namespace ABCofRealEstate.Data.Models.Interfaces
{
    /// <summary> Жилое помещение в здании </summary>
    public interface IRoomInBuilding : IBuilding, IResidentialProperty
    {
        /// <summary> Номер квартиры </summary>
        public short NumberApartament { get; set; }
        /// <summary> Количество балконов </summary>
        public short CountBalcony { get; set; }
    }
}
