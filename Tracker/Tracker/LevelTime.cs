
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class LevelTime : Event
    {
        public float iniTime;
        public float totalTime;
        public LevelTime()
        {
            Event_type = "Level_Time";
        }

        public void StartTimer(float iniTime_)
        {
            iniTime = iniTime_;
        }

        public void TotalTime(float endTime)
        {
            totalTime = endTime - iniTime;
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
