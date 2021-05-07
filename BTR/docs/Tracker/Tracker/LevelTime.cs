using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class LevelTime : Event
    {
        public LevelTime()
        {
            event_type = "Level Time";
        }

        public override void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile;
            }
            File.WriteAllText(path, jsonFile);
        }
    }
}
