using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class GrenadeUsage : Event
    {
        public int counter;
        public GrenadeUsage()
        {
            Event_type = "Grenade_Usage";
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
