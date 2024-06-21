namespace ConsoleParkingSystem.Models
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public VehicleType Type { get; set; } // "Mobil" or "Motor"

        public Vehicle(string registrationNumber, string color, string type)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            Type = type;
        }
    }

}