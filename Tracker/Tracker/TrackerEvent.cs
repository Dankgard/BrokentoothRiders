using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Tracker
{
    public class TrackerEvent
    {
        public enum EventType
        {
            SESSION_START,
            LEVEL_START,
            LEVEL_END,
            SESSION_END,
            LEVEL_TIME,
            DAMAGE_FREQUENCY,
            HIT_FREQUENCY,
            WEAPON_USAGE_FREQUENCY,
            WEAPON_ACCURACY
        }

        public string eventType;
        public DateTime timestamp_;
        EventType eventTypeEnum_;
        public string idGame;
        public string idSession;

        public TrackerEvent(EventType type)
        {
            //idGame = se le da desde Tracker que es singleton
            //idSession = se le da desde Tracker que es singleton
            eventTypeEnum_ = type;
            eventType = eventTypeEnum_.ToString();
            timestamp_ = DateTime.Now;
        }

        public virtual void toJson(out string inf)
        {
            inf = "";            
        }

        public EventType GetEventType()
        {
            return eventTypeEnum_;
        }

    }
}
