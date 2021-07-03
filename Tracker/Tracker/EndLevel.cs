using System;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class EndLevel : TrackerEvent
    {
        public string endLevelTime;

        public EndLevel() : base(EventType.LEVEL_END)
        {
            // Momento en el que acaba el nivel
            DateTime endTime = DateTime.Now;
            endLevelTime = endTime.ToString();
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
