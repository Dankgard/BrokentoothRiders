using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    public abstract class Event
    {
        public string event_type { get; set; }
        public abstract void ToJson(string path);
    }
}
