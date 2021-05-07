using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartLevel : Event
    {
        private float level_id;
        private string levelStartTime;

        public StartLevel(float level)
        {
            event_type = "Start_Level";
            level_id = level;

            // Momento en el que empieza el nivel
            DateTime startTime = DateTime.Now;
            levelStartTime = startTime.ToString();
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
