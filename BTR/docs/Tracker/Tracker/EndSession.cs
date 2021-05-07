using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class EndSession : Event
    {
        public string sessionEndTime;
        public EndSession()
        {
            event_type = "End_Session";

            // Momento en que acaba la sesion
            DateTime endTime = DateTime.Now;
            sessionEndTime = endTime.ToString();
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
