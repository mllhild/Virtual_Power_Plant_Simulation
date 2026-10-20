namespace VirtualPowerPlant_Simulation_Prototype
{
    public class Hardware : Entity
    {
        public Hardware() { location = new Location(); name = "nameless"; }
        public Hardware(Location location, string name, bool canBeTurnedOff, bool isTurnedOff, float capacity_max, float capacity_min, float capacity_current, float load_max, float load_min, float load_current)
        {
            this.location = location;
            this.name = name;
            this.canBeTurnedOff = canBeTurnedOff;
            this.isTurnedOff = isTurnedOff;
            this.storageCapacity_max = capacity_max;
            this.storageCapacity_min = capacity_min;
            this.storageCapacity_current = capacity_current;
            this.load_max = load_max;
            this.load_min = load_min;
            this.load_current = load_current;
        }

        public Location location;
        public string name;
        
        public bool canBeTurnedOff = false;
        public bool isTurnedOff = false;
        // Storage Capacity
        public float storageCapacity_max = 0;
        public float storageCapacity_min = 0;
        public float storageCapacity_current = 0;
        public float storageCapacity_target = 0;
        // Dispatch Speed
        public float load_max = 0;
        public float load_min = 0;
        public float load_current = 0;
        public float load_target = 0;
        // Time
        public virtual void Step(float dt) {
            if (isTurnedOff) return;
            load_current = load_target;
            if(storageCapacity_max > 0)
            {
                // storage empty
                if (storageCapacity_current <= 0) { storageCapacity_current = 0; load_current = 0; }
                // storage full
                if (storageCapacity_current >= storageCapacity_max) { storageCapacity_current = storageCapacity_max; load_current = 0; }
                // target load exceeded, no more energy input accepted
                if (storageCapacity_current > storageCapacity_target && load_current < 0) { load_current = 0; }
                // target load undercut, no more energy dispatch accepted
                if (storageCapacity_current < storageCapacity_target && load_current > 0) { load_current = 0; }
            }
            storageCapacity_current -= dt * load_current;
        }
        public virtual void Load_Update(float load_target) {
            if (load_target > load_max) { Logger.Log("Overload request:"+load_max + " / " + load_target); load_target = load_max; }
            if (load_target < load_min) { Logger.Log("Underload request:" + load_min + " / " + load_target); load_target = load_min; }
            this.load_target = load_target;

        }
        public virtual void CapacityTarget_Update(float target_capacity)
        {
            if (target_capacity > storageCapacity_max) { Logger.Log("Overcharge request:" + storageCapacity_max + " / " + target_capacity); target_capacity = storageCapacity_max; }
            if (target_capacity < storageCapacity_min) { Logger.Log("Undercharge request:" + storageCapacity_min + " / " + target_capacity); target_capacity = storageCapacity_min; }
            load_current = target_capacity;
        }
        public virtual void TurnOff(bool isTurnedOff) {  
            if (!canBeTurnedOff) { Logger.Log("cant be turned off: " + ID); return; }
            this.isTurnedOff = isTurnedOff;
        }
    }
}