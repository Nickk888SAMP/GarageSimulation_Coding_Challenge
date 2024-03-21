
namespace GarageSimulation_Codingchallenge.Classes
{
    public class ParkingSpot
    {
        public VehicleBase ParkedVehicle { get; private set; } = null;
        public GarageFloor GarageFloor { get; private set; } = null;
        public int ParkingSpotNumber { get; private set; }

        public ParkingSpot(GarageFloor garageFloor, int parkingSpotNumber)
        {
            GarageFloor = garageFloor;
            ParkingSpotNumber = parkingSpotNumber;
        }

        public void AssignVehicleToParkingSpace(VehicleBase vehicle)
            => ParkedVehicle = vehicle;

        public bool IsOccupied() => ParkedVehicle != null;
        public void Unassign() => ParkedVehicle = null;
    }
}
