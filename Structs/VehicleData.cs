using GarageSimulation_Codingchallenge.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSimulation_Codingchallenge.Structs
{
    public struct VehicleData
    {
        public VehicleBase Vehicle { get; private set; }
        public ParkingSpot ParkingSpace { get; private set; }
        public GarageFloor GarageFloor { get; private set; }

        public VehicleData(GarageFloor GarageFloor, ParkingSpot ParkingSpace, VehicleBase Vehicle)
        {
            this.GarageFloor = GarageFloor;
            this.ParkingSpace = ParkingSpace;
            this.Vehicle = Vehicle;
        }
    }
}
