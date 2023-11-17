namespace ABCofRealEstate.Data.Models.Interfaces
{
    public interface IRoomInBuilding : IBuilding
    {
        public int NumberApartament { get; set; }
        public int CountBalcony { get; set; }
    }
}
