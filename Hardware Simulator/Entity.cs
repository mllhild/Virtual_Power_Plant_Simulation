namespace VirtualPowerPlant_Simulation_Prototype
{
    public class Entity
    {
        private string id = "0";
        public Entity() => id = Guid.NewGuid().ToString();
        public string ID { get { return id; } }
        public Dictionary<string, string> Properties;
    }
}