using System;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class EndLevel : TrackerEvent
    {

        public EndLevel() : base(EventType.LEVEL_END)
        {
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
