using System;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class StartLevel : TrackerEvent
    {
        public string level_id;

        public StartLevel(string level) : base(EventType.LEVEL_START)
        {
            level_id = level;
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
