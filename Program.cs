using System;
using GarageSimulation_Codingchallenge.Classes;

namespace GarageSimulation_Codingchallenge.Program
{
    public class Program
    {
        public static GarageManager GarageManager { get; set; }
        public static GarageClient GarageClient { get; set; }

        static void Main(string[] args)
        {
            Console.Title = "Garage Simulation Coding Challenge";
            int floors = 0;
            int spots = 0;
            while (GarageClient == null)
            {
                if (floors <= 0)
                {
                    Console.Write("How many floors do you want to create?: ");
                }
                else if (spots <= 0)
                {
                    Console.Write("How many parking spots do you want to create?: ");
                }
                string command = Console.ReadLine();
                if (command.Length == 0)
                    continue;

                int commandInteger = Convert.ToInt32(command);
                if (floors <= 0)
                    floors = commandInteger;
                else if (spots <= 0)
                    spots = commandInteger;

                if(floors > 0 && spots > 0)
                    break;
            }
            GarageManager = new GarageManager(floors, spots);
            GarageClient = new GarageClient();
            GarageClient.Start();
        }
    }
}
