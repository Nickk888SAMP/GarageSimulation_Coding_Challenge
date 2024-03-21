using GarageSimulation_Codingchallenge.Classes;

namespace GarageSimulation_Codingchallenge.Program
{
    public class GarageManager
    {
        public static GarageManager Instance { get; private set; }

        public Garage Garage { get; set; }
        public int ParkingFloors = 0;
        public int ParkingSpacesPerFloor = 0;

        public GarageManager(int parkingFloors, int parkingSpacesPerFloor) 
        {
            Instance = this;
            ParkingFloors = parkingFloors;
            ParkingSpacesPerFloor = parkingSpacesPerFloor;
            Garage = new Garage(ParkingFloors, ParkingSpacesPerFloor);
        }
    }
}
