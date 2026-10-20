using System.Numerics;

namespace VirtualPowerPlant_Simulation_Prototype
{
    public class Location
    {
        public Vector3 position;
        public string country;
        public Location() { position = Vector3.Zero; country = "unknown"; }
        public Location(Vector3 Position, string Country="unknown") { position = Position; country = Country; }
    }
}