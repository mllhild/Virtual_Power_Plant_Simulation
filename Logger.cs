namespace VirtualPowerPlant_Simulation_Prototype
{
    public static class Logger
    {
        static List<string> logs = new List<string>();
        public static void Log(string message) => logs.Add(message);
    }
}