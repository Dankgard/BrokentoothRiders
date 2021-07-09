using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartSession : TrackerEvent
    {

        public StartSession() : base(EventType.SESSION_START)
        {
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
