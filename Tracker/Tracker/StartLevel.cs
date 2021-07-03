using System;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartLevel : TrackerEvent
    {
        public string level_id;
        public string levelStartTime;

        public StartLevel(string level) : base(EventType.HIT_FREQUENCY)
        {
            level_id = level;

            // Momento en el que empieza el nivel
            DateTime startTime = DateTime.Now;
            levelStartTime = startTime.ToString();
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
