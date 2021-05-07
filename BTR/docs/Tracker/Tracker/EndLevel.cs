using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class EndLevel : Event
    {
        public string endLevelTime;

        public EndLevel()
        {
            event_type = "End_Level";

            // Momento en el que acaba el nivel
            DateTime endTime = DateTime.Now;
            endLevelTime = endTime.ToString();
        }

        public override void ToJson(string path)
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
