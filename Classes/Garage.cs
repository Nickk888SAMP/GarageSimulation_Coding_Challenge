using GarageSimulation_Codingchallenge.Structs;
using System.Collections.Generic;

namespace GarageSimulation_Codingchallenge.Classes
{
    public class Garage
    {
        public List<GarageFloor> GarageFloors = null;

        public enum EAssignVehicleToGarageError
        {
            None,
            NoSpaceException,
            AlreadyExistsException
        }

        public enum EVehicleType
        {
            Car,
            Motorcycle
        }

        public Garage(int parkingFloorCapacity, int parkingSpaceCapacity)
        {
            GarageFloors = new List<GarageFloor>(parkingFloorCapacity);
            for (int i = 0; i < parkingFloorCapacity; i++)
            {
                GarageFloors.Add(new GarageFloor(parkingSpaceCapacity, i));
            }
        }

        public bool AssignVehicleToAvailableParkingSpace(string licensePlate, EVehicleType VehicleType ,out VehicleData vehicleData, out EAssignVehicleToGarageError eAssignVehicleToGarageError)
        {
            if (GetVehicleByLicensePlate(licensePlate, out vehicleData))
            {
                eAssignVehicleToGarageError = EAssignVehicleToGarageError.AlreadyExistsException;
                return false;
            }

            if (GetFreeParkingSpace(out GarageFloor garageFloor, out ParkingSpot parkingSpace))
            {
                VehicleBase vehicle = new VehicleBase();
                vehicle.SetLicensePlate(licensePlate);
                parkingSpace.AssignVehicleToParkingSpace(vehicle);
                vehicleData = new VehicleData(garageFloor, parkingSpace, vehicle);
                eAssignVehicleToGarageError = EAssignVehicleToGarageError.None;
                return true;
            }
            eAssignVehicleToGarageError = EAssignVehicleToGarageError.NoSpaceException;
            return false;
        }

        /// <summary>
        /// Removes a Vehicle from the Garage using the License Plate
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <returns></returns>
        public bool RemoveVehicleFromGarage(string licensePlate)
        {
            if(GetVehicleByLicensePlate(licensePlate, out VehicleData vehicleData))
            {
                vehicleData.ParkingSpace.Unassign();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Counts the Free Parking Spots in the Garage
        /// </summary>
        /// <returns></returns>
        public int CountFreeParkingSpots()
        {
            int freeParkingSpaces = 0;
            foreach(var floor in GarageFloors)
            {
                freeParkingSpaces += floor.CountFreeParkingSpots();
            }
            return freeParkingSpaces;
        }

        /// <summary>
        /// Counts the occupied Parking Spots in the Garage
        /// </summary>
        /// <returns></returns>
        public int CountOccupiedParkingSpots()
        {
            int occupiedParkingSpaces = 0;
            foreach (var floor in GarageFloors)
            {
                occupiedParkingSpaces += floor.CountOccupiedParkingSpots();
            }
            return occupiedParkingSpaces;
        }

        /// <summary>
        /// Gets a free Parking space
        /// </summary>
        /// <param name="parkingSpace"></param>
        /// <returns></returns>
        public bool GetFreeParkingSpace(out GarageFloor garageFloor, out ParkingSpot parkingSpace)
        {
            foreach (var floor in GarageFloors)
            {
                if (!floor.ParkingSpaceAvailable())
                    continue;

                garageFloor = floor;
                parkingSpace = floor.GetFreeParkingSpot();
                return true;
            }
            garageFloor = null;
            parkingSpace = null;
            return false;
        }

        /// <summary>
        /// Tries to get the Vehicle by the License Plate
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="vehicleData"></param>
        /// <returns></returns>
        public bool GetVehicleByLicensePlate(string licensePlate, out VehicleData vehicleData)
        {
            foreach(var floor in GarageFloors)
            {
                if(floor.GetVehicleByLicensePlate(licensePlate, out VehicleBase vehicle, out GarageFloor garageFloor, out ParkingSpot parkingSpace))
                {
                    vehicleData = new VehicleData(garageFloor, parkingSpace, vehicle);
                    return true;
                }
            }
            vehicleData = new VehicleData(null, null, null);
            return false;
        }
    }
}
