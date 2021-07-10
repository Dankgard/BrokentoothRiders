using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class EndSession : TrackerEvent
    {
        public EndSession() : base(EventType.SESSION_END)
        {
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
