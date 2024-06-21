using System;
using ConsoleParkingSystem.Models;

namespace ConsoleParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingSystem parkingSystem = null;

            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                switch (command[0])
                {
                    case "create_parking_lot":
                        int totalSlots = int.Parse(command[1]);
                        parkingSystem = new ParkingSystem(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                        break;

                    case "park":
                        string regNumber = command[1];
                        string color = command[2];
                        VehicleType type = Enum.Parse<VehicleType>(command[3], true);
                        var vehicle = new Vehicle(regNumber, color, type);
                        Console.WriteLine(parkingSystem.ParkVehicle(vehicle));
                        break;

                    case "leave":
                        int slotNumber = int.Parse(command[1]);
                        Console.WriteLine(parkingSystem.Leave(slotNumber));
                        break;

                    case "status":
                        Console.WriteLine(parkingSystem.GetStatus());
                        break;

                    case "type_of_vehicles":
                        VehicleType vehicleType = Enum.Parse<VehicleType>(command[1], true);
                        Console.WriteLine(parkingSystem.GetVehicleCountByType(vehicleType));
                        break;

                    case "registration_numbers_for_vehicles_with_odd_plate":
                        Console.WriteLine(parkingSystem.GetRegistrationNumbersByPlateType(true));
                        break;

                    case "registration_numbers_for_vehicles_with_even_plate":
                        Console.WriteLine(parkingSystem.GetRegistrationNumbersByPlateType(false));
                        break;

                    case "registration_numbers_for_vehicles_with_colour":
                        string vehicleColor = command[1];
                        Console.WriteLine(parkingSystem.GetRegistrationNumbersByColor(vehicleColor));
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        vehicleColor = command[1];
                        Console.WriteLine(parkingSystem.GetSlotNumbersByColor(vehicleColor));
                        break;

                    case "slot_number_for_registration_number":
                        regNumber = command[1];
                        Console.WriteLine(parkingSystem.GetSlotNumberByRegistrationNumber(regNumber));
                        break;

                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
