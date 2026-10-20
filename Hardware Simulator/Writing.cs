using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPowerPlant_Simulation_Prototype
{
    internal class Writing
    {
    }

    public static class WeatherDataStorage
    {
        static public Dictionary<string, WeatherData> dic_WeatherData = new Dictionary<string, WeatherData>();
        static public Dictionary<string, LocationData> dic_LocationData = new Dictionary<string, LocationData>();
        static public void LoadWeatherData(string path = @"C:\Users\andre.martin\source\repos\VirtualPowerPlant_Simulation_Prototype\Data\Weather Data.csv")
        {
            string[] lines = File.ReadAllLines(path);
            int lenght = lines.Length;
            for(int i = 1; i<lenght; i++)
            {
                try
                {
                    WeatherData data = new WeatherData(lines[i]);
                    dic_WeatherData.Add(data.location_id.ToString() + data.time.ToString(), data);
                }
                catch(Exception ex) {
                    Logger.Log($"{nameof(WeatherDataStorage)}.{nameof(LoadWeatherData)} Error: {ex}");
                }
                
            }
        }
        static public void LoadLocationData(string path = @"C:\Users\andre.martin\source\repos\VirtualPowerPlant_Simulation_Prototype\Data\Weather Locations.csv")
        {
            string[] lines = File.ReadAllLines(path);
            int lenght = lines.Length;
            for (int i = 1; i < lenght; i++)
            {
                try
                {
                    LocationData data = new LocationData(lines[i]);
                    dic_LocationData.Add(data.location_id.ToString() + data.time.ToString(), data);
                }
                catch (Exception ex)
                {
                    Logger.Log($"{nameof(WeatherDataStorage)}.{nameof(LoadLocationData)} Error: {ex}");
                }

            }
        }
    }
    public class WeatherData
    {
        // location_id,time,temperature_2m (°C),shortwave_radiation (W/m²),cloud_cover (%),wind_speed_10m (km/h),wind_speed_80m (km/h)
        // 0,2026-10-01T00:00,17.0,0.0,100,16.2,32.0
        public int location_id;
        public DateTime time;
        public float temperature_C;
        public float shortwave_radiation;
        public float cloud_coverPercentage;
        public float wind_speed_at_10m;
        public float wind_speed_at_80m;

        public WeatherData(string data)
        {
            string[] strings = data.Split(',');
            location_id = int.Parse(strings[0]);
            time = DateTime.Parse(strings[1]);
            temperature_C = float.Parse(strings[2]);
            shortwave_radiation = float.Parse(strings[3]);
            cloud_coverPercentage = float.Parse(strings[4]);
            wind_speed_at_10m = float.Parse(strings[5]);
            wind_speed_at_80m = float.Parse(strings[6]);
        }
    }
    public class LocationData
    {
        // location_id,latitude,longitude,elevation,utc_offset_seconds,timezone,timezone_abbreviation
        // 0,2026-10-01T00:00,17.0,0.0,100,16.2,32.0
        
        public int location_id;
        public DateTime time;
        public LocationData(string data)
        {
            string[] strings = data.Split(',');
            location_id = int.Parse(strings[0]);
            time = DateTime.Parse(strings[1]);
        }
    }
    public class Weather
    {
        private float GetSunInclination(Location location, DateTime currentTime) { return 1f; }
        private float GetCloudCoverageFactor(Location location, DateTime currentTime) { return 1f; }
        public float SolarEfficiencyFactor(Location location, DateTime time) { return GetSunInclination(location, time) * GetCloudCoverageFactor(location, time); }


        private float GetWindFactor(Location location, DateTime currentTime) { return 1f; }
        public float WindEfficiencyFactor(Location location, DateTime time) { return GetWindFactor(location, time); } 
    }
}