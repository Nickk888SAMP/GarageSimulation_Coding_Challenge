using GarageSimulation_Codingchallenge.Program;
using System;
using GarageSimulation_Codingchallenge.Structs;

namespace GarageSimulation_Codingchallenge.Classes
{
    public class GarageClient
    {
        public void Start()
        {
            Clear();
            while (true)
            {
                Console.Write("\nCommand: ");
                string command = Console.ReadLine();
                HandleCommand(command);
            }
        }

        private void HandleCommand(string command)
        {
            string[] commandSplit = command.Split(' ');
            if (commandSplit.Length == 0)
                return;

            switch(commandSplit[0])
            {
                case "add":
                {
                    if(commandSplit.Length == 3)
                    {
                        if(GarageManager.Instance.Garage.AssignVehicleToAvailableParkingSpace(
                        commandSplit[1],
                        Convert.ToInt32(commandSplit[2]) == 0 ? Garage.EVehicleType.Car : Garage.EVehicleType.Motorcycle,
                        out VehicleData vehicleData,
                        out Garage.EAssignVehicleToGarageError errorException))
                        {
                            Console.WriteLine($"Vehicle Added\nLicense Plate: {vehicleData.Vehicle.LicensePlate}\nFloor: {vehicleData.GarageFloor.ParkingFloorNumber}\nSpot: {vehicleData.ParkingSpace.ParkingSpotNumber}");
                        }
                        else
                        {
                            switch(errorException)
                            {
                                case Garage.EAssignVehicleToGarageError.NoSpaceException:
                                {
                                    Console.WriteLine("Vehicle couldnt't be added. No space available!");
                                    break;
                                }
                                case Garage.EAssignVehicleToGarageError.AlreadyExistsException:
                                {
                                    Console.WriteLine("Vehicle couldnt't be added. Vehicle already exists!");
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
                case "remove":
                {
                    if (commandSplit.Length == 2)
                    {
                        if (GarageManager.Instance.Garage.RemoveVehicleFromGarage(commandSplit[1]))
                        {
                            Console.WriteLine($"Vehicle deleted!");
                        }
                        else Console.WriteLine("Vehicle wasn't found!");
                    }
                    break;
                }
                case "stats":
                {
                    ShowStats();
                    break;
                }
                case "clear":
                {
                    Clear();
                    break;
                }
                case "search":
                {
                    if (commandSplit.Length == 2)
                    {
                        if (GarageManager.Instance.Garage.GetVehicleByLicensePlate(commandSplit[1], out VehicleData vehicleData))
                        {
                            Console.WriteLine($"Vehicle Found\nLicense Plate: {vehicleData.Vehicle.LicensePlate}\nFloor: {vehicleData.GarageFloor.ParkingFloorNumber}\nSpot: {vehicleData.ParkingSpace.ParkingSpotNumber}");
                        }
                        else Console.WriteLine("Vehicle wasn't found!");
                    }
                    break;
                }
            }
        }

        private void ShowStats()
        {
            Console.WriteLine($"Available Parking Spots: {GarageManager.Instance.Garage.CountFreeParkingSpots()}");
            Console.WriteLine($"Occupied Parking Spots: {GarageManager.Instance.Garage.CountOccupiedParkingSpots()}");
        }

        private void Clear()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Garage Simulation");
            Console.ResetColor();
            Console.WriteLine("Available Commands:\n- add [License Plate] [0 = Car | 1 = Motorcycle]\n- remove [License Plate]\n- stats\n- search [License Plate]");
        }
    }
}
