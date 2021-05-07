using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{

    class Tracker
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

        private bool trackerActive { get; }
        private string levelId { get; }
        private string sessionId { get; }

        private string filePath;

        public List<Event> events { get; }

        public Tracker()
        {
            events = new List<Event>();
        }

        public void SetFilePath(string path)
        {
            filePath = path;
        }

        public void RegisterEvent(EventType event_type, string[] args)
        {
            switch(event_type)
            {
                case EventType.SESSION_START:
                    if (events[0] == null)
                    {
                        StartSession startSession = new StartSession();
                        events[0] = startSession;
                    }
                    events[0].ToJson(filePath);
                    break;
                case EventType.SESSION_END:
                    if (events[1] == null)
                    {
                        EndSession endSession = new EndSession();
                        events[1] = endSession;
                    }
                    events[1].ToJson(filePath);
                    break;
                case EventType.LEVEL_START:
                    if (events[2] == null)
                    {
                        StartLevel startLevel = new StartLevel(args[0]);
                        events[2] = startLevel;
                    }
                    events[2].ToJson(filePath);
                    break;
                case EventType.LEVEL_END:
                    if (events[3] == null)
                    {
                        EndLevel endLevel = new EndLevel();
                        events[3] = endLevel;
                    }
                    events[3].ToJson(filePath);
                    break;
                case EventType.LEVEL_TIME:
                    if (events[4] == null)
                    {
                        LevelTime levelTime = new LevelTime();
                        events[4] = levelTime;
                    }
                    events[4].ToJson(filePath);
                    break;
                case EventType.DAMAGE_FREQUENCY:
                    if (events[5] == null)
                    {
                        DamageFrequency damageFrequency = new DamageFrequency();
                        events[5] = damageFrequency;
                    }
                    //events[5].AddPosition(args[0], args[1]);
                    events[5].ToJson(filePath);
                    break;
                case EventType.HIT_FREQUENCY:
                    if (events[6] == null)
                    {
                        HitFrequency hitFrequency = new HitFrequency();
                        events[6] = hitFrequency;
                    }
                    // metodo
                    events[6].ToJson(filePath);
                    break;
                case EventType.WEAPON_USAGE_FREQUENCY:
                    if (events[7] == null)
                    {
                        WeaponUsageFrequency weaponUsageFrequency = new WeaponUsageFrequency();
                        events[7] = weaponUsageFrequency;
                    }
                    events[7].ToJson(filePath);
                    break;
                case EventType.WEAPON_ACCURACY:
                    if(events[8] == null)
                    {
                        WeaponAccuracy weaponAccuracy = new WeaponAccuracy();
                        events[8] = weaponAccuracy;
                    }
                    events[8].ToJson(filePath);
                    break;
                default:
                    break;
            }
        }
    }
}
