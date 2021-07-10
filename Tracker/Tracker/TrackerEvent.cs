using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TrackerSpace
{
    public class TrackerEvent
    {
        public enum EventType
        {
            SESSION_START,
            LEVEL_START,
            LEVEL_END,
            SESSION_END,
            PLAYER_HIT,
            ENEMY_MAKES_DAMAGE,
            WEAPON_CHANGE,
            WEAPON_SHOT_RESULT
        }

        public string eventType;
        public double timestamp_;
        EventType eventTypeEnum_;
        public string idGame;
        public string idSession;

        public TrackerEvent(EventType type)
        {
            eventTypeEnum_ = type;
            eventType = eventTypeEnum_.ToString();
            timestamp_ = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds; ; //Una forma en convertirlos a epoch
        }
        public void setID(string idGame_, string idSession_)
        {
            idGame = idGame_;
            idSession = idSession_;
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
