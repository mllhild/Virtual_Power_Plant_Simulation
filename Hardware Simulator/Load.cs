namespace VirtualPowerPlant_Simulation_Prototype
{
    public class Load : Hardware
    {
        public Load_Type type;
        public Load() { type = Load_Type.Unknown; }
        public Load(Load_Type type, Location location, string name, bool canBeTurnedOff, bool isTurnedOff, float capacity_max, float capacity_min, float capacity_current, float load_max, float load_min, float load_current)
        {
            this.type = type;
            this.location = location;
            this.name = name;
            this.canBeTurnedOff = canBeTurnedOff;
            this.isTurnedOff = isTurnedOff;
            this.storageCapacity_max = capacity_max;
            this.storageCapacity_min = capacity_min;
            this.storageCapacity_current = capacity_current;
            this.storageCapacity_target = capacity_max;
            this.load_max = load_max;
            this.load_min = load_min;
            this.load_current = load_current;
        }
        public override void Step(float dt)
        {
            base.Step(dt);
        }
        public override void Load_Update(float target_load)
        {
            base.Load_Update(target_load);
        }
    }
}