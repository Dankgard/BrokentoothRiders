
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class LevelTime : Event
    {
        public LevelTime()
        {
            Event_type = "Level_Time";
        }

        public override void ToJson(string path)
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
