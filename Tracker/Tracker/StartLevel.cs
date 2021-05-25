using System;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartLevel : Event
    {
        public string level_id;
        public string levelStartTime;

        public StartLevel(string level)
        {
            Event_type = "Start_Level";
            level_id = level;

            // Momento en el que empieza el nivel
            DateTime startTime = DateTime.Now;
            levelStartTime = startTime.ToString();
        }
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile + "\n";
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, jsonFile);
        }
    }
}
