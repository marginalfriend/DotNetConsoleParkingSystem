using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleParkingSystem.Models
{
    public class ParkingSystem
    {
        private List<ParkingLot> parkingLots;

        public ParkingSystem(int totalSlots)
        {
            // Giving parkingLots a list value of ParkingLot
            parkingLots = new List<ParkingLot>();

            // Adding new ParkingLots into the container as much as the parameter
            for (int i = 1; i <= totalSlots; i++)
            {
                parkingLots.Add(new ParkingLot(i));
            }
        }

        public string ParkVehicle(Vehicle vehicle) 
        {
            // FirstOrDefault will get
            var availableLot = parkingLots.FirstOrDefault(lot => lot.IsAvailable);
            // public bool IsAvailable => ParkedVehicle == null;  <<<<<  This is the property IsAvailable in ParkingLot class
            if (availableLot != null) 
            {
                availableLot.ParkedVehicle = vehicle;
                return $"Allocated slot number: {availableLot.SlotNumber}"
            }
            else
            {
                return "Sorry parking lot is full";
            }
        }

        public string Leave(int slotNumber)
        {
            var parkingLot = parkingLots.FirstOrDefault(lot => lot.SlotNumber == slotNumber);
            if (parkingLot != null && !parkingLot.IsAvailable)
            {
                parkingLot.ParkedVehicle = null;
                return $"Slot number {slotNumber} is free";
            }
            else
            {
                return "Slot is already free or does not exist";
            }
        }

        public string GetStatus()
        {
            var status = new StringBuilder();
            status.AppendLine("Slot\tNo.\tType\tRegistration No\tColour");
            foreach (var lot in parkingLots.Where(lot => !lot.IsAvailable))
            {
                status.AppendLine($"{lot.SlotNumber}\t{lot.ParkedVehicle.RegistrationNumber}\t{lot.ParkedVehicle.Type}\t{lot.ParkedVehicle.RegistrationNumber}\t{lot.ParkedVehicle.Color}");
            }
            return status.ToString();
        }
    }
}