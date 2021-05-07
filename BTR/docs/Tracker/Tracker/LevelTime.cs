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
            Metric = "Level Time";
            Time = 0;
        }

        public void StartTimer(float startTimer)
        {
            Time = startTimer;
        }

        public void StopTimer(float FinalTimer)
        {
            Time = FinalTimer - Time;
        }
        public override void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, jsonFile);
        }
    }
}
