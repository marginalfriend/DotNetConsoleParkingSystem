﻿using System;
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
                        if (command.Length != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid amount of argument");
                            Console.WriteLine("     Usage: create_parking_lot <amount of parking lots>");
                            Console.WriteLine("     Example: create_parking_lot 5 <--- this will create 5 parking lots");

                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        } else if (int.Parse(command[1]) == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Invalid type: It has to be a number");

                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }
                        int totalSlots = int.Parse(command[1]);
                        parkingSystem = new ParkingSystem(totalSlots);
                        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
                        break;

                    case "park":
                        if (command.Length != 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Invalid amount of argument");
                            Console.WriteLine("Usage: park <regNumber> <color> <type>");
                            Console.WriteLine("Example: park B-123-XYZ RED Mobil");

                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        } else if (Enum.Parse<VehicleType>(command[3], true) == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Invalid type: Only Mobil and Motor is accepted");

                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }
                        string regNumber = command[1];
                        string color = command[2];
                        VehicleType type = Enum.Parse<VehicleType>(command[3], true);
                        var vehicle = new Vehicle(regNumber, color, type);
                        Console.WriteLine(parkingSystem.ParkVehicle(vehicle));
                        break;

                    case "leave":
                        if (command.Length != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Invalid amount of argument");
                            Console.WriteLine("Usage: leave <lot_number>");
                            Console.WriteLine("Example: leave 2");

                            Console.ResetColor();
                            Console.WriteLine();
                            break;
                        }
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
