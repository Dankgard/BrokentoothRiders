using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class EndSession : TrackerEvent
    {
        public string sessionEndTime;
        public EndSession() : base(EventType.SESSION_END)
        {
            // Momento en que acaba la sesion
            DateTime endTime = DateTime.Now;
            sessionEndTime = endTime.ToString();
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
