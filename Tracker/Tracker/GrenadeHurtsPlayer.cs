using Newtonsoft.Json;
using System.IO;

namespace Final_Tracker
{
    class GrenadeHurtsPlayer : Event
    {
        public int numberOfTimes;
        public GrenadeHurtsPlayer()
        {
            Event_type = "Grenade hurts player";
            numberOfTimes = 0;
        }
        public void addCurrency()
        {
            ++numberOfTimes;
        }
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile;
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, jsonFile);
        }
    }
}
