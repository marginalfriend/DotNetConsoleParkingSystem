namespace ConsoleParkingSystem.Models
{
    public class ParkingLot
    {
        public int SlotNumber { get; set; }
        public Vehicle ParkedVehicle { get; set; }

        public bool IsAvailable => ParkedVehicle == null;

        public ParkingLot(int slotNumber)
        {
            SlotNumber = slotNumber;
        }
    }
}