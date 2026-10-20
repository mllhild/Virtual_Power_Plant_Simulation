namespace VirtualPowerPlant_Simulation_Prototype
{
    public static class HardwareSimulator
    {
        static public Dictionary<string,Hardware> dic_hardware = new Dictionary<string,Hardware>();
        static public float stepInterval = 5;
        static public Queue<Command> commands = new Queue<Command>();

        static public void AddCommand(Command command) => commands.Enqueue(command);
        static public void ProcessCommands()
        {
            while (commands.Count > 0)
            {
                Command command = commands.Dequeue();
                if(!dic_hardware.ContainsKey(command.target_Id)) {Logger.Log("hardware id not found: " + command.target_Id); continue;}
                switch (command.type)
                {
                    case Command_Type.Unknown:
                        Logger.Log("Unknown Command");
                        break;
                    case Command_Type.StateChange:
                        if (command.value == 0)
                            dic_hardware[command.target_Id].TurnOff(true);
                        else
                            dic_hardware[command.target_Id].TurnOff(false);
                        break;
                    case Command_Type.LoadChange:
                        dic_hardware[command.target_Id].Load_Update(command.value);
                        break;
                    case Command_Type.CapacityTargetChange:
                        dic_hardware[command.target_Id].CapacityTarget_Update(command.value);
                        break;
                }
            }
        }

    public enum Command_Type
    {
        Unknown = 0,
        StateChange = 1,
        LoadChange = 2,
        CapacityTargetChange = 3,
    }
    public class Command : Entity
    {
        public string target_Id;
        public Command_Type type;
        public float value;
        public Command(string target_Id, Command_Type type, float value)
        {
            this.target_Id = target_Id;
            this.type = type;
            this.value = value;
        }
    }
    }
}