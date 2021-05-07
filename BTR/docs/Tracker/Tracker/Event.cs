using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    public enum EventType
    {
        DAMAGE_FREQUENCY,
        HIT_FREQUENCY,
        LEVEL_TIME,
        WEAPON_USAGE_FREQUENCY,
        WEAPON_ACCURACY,
        SESSION_START,
        LEVEL_START,
        LEVEL_END,
        SESSION_END
    }

    public abstract class Event
    {
        public string Metric { get; set; }
        public int Level { get; set; }

        public EventType eventType { get; set; }
        public string levelId { get; set; }
        public string sessionId { get; set; }

        public abstract void ToJson(string path);
    }
}
