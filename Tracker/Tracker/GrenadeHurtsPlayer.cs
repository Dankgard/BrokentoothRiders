using Newtonsoft.Json;
using System.IO;

namespace Tracker
{
    class GrenadeHurtsPlayer : Event
    {
        public int counter;
        public GrenadeHurtsPlayer()
        {
            Event_type = "Grenade hurts player";
            counter = 0;
        }
        public void AddEntry()
        {
            counter++;
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
