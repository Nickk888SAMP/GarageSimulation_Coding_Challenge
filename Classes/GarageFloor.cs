using System.Collections.Generic;
using System.Linq;

namespace GarageSimulation_Codingchallenge.Classes
{
    public class GarageFloor
    {
        public List<ParkingSpot> ParkingSpots { get; private set; } = null;
        public int ParkingSpaceCapacity { get; private set; }
        public int ParkingFloorNumber { get; private set; }

        public GarageFloor(int parkingSpaceCapacity, int floorNumber)
        {
            ParkingSpaceCapacity = parkingSpaceCapacity;
            ParkingFloorNumber = floorNumber;
            ParkingSpots = new List<ParkingSpot>(ParkingSpaceCapacity);
            for (int i = 0; i < ParkingSpaceCapacity; i++)
            {
                ParkingSpots.Add(new ParkingSpot(this, i));
            }
        }

        public bool ParkingSpaceAvailable() => GetFreeParkingSpot() != null;
        public ParkingSpot GetFreeParkingSpot() => ParkingSpots.FirstOrDefault(i => !i.IsOccupied());
        public int CountFreeParkingSpots() => ParkingSpots.Where(i => !i.IsOccupied()).Count();
        public int CountOccupiedParkingSpots() => ParkingSpots.Where(i => i.IsOccupied()).Count();
        public bool GetVehicleByLicensePlate(string licensePlate, out VehicleBase vehicle, out GarageFloor floor, out ParkingSpot parkingSpace)
        {
            foreach (var space in ParkingSpots)
            {
                if(!space.IsOccupied())
                    continue;

                if(space.ParkedVehicle.CompareLicensePlate(licensePlate))
                {
                    vehicle = space.ParkedVehicle;
                    floor = this;
                    parkingSpace = space;
                    return true;
                }
            }
            vehicle = null;
            floor = null;
            parkingSpace = null;
            return false;
        }
    }
}
