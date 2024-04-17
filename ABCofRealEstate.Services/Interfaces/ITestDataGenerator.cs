namespace ABCofRealEstate.Services.Interfaces;

public interface ITestDataGenerator
{
    Task<Apartment> GetGenerationApartment();
    Task<Area> GetGenerationArea();
    Task<Comertion> GetGenerationComertion();
    Employee GetGenerationEmployee();
    Task<Garage> GetGenerationGarage();
    Task<Hostel> GetGenerationHostel();
    Task<House> GetGenerationHouse();
    Moderator GetGenerationModerator();
    Task<Room> GetGenerationRoom();
}