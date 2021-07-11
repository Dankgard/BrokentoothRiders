using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrackerSpace
{
    public class Tracker
    {
        private static Tracker _instance = null;
        IPersistence persistence_;
        List<ITrackerAsset> activeTrackers_ = new List<ITrackerAsset>();

        public enum TrackersType
        {
            BTR_TRACKER
        }

        public enum SerializerType
        {
            JSON, NONE
        }

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

        string idGame_;
        string idSession_;

        private Tracker() { }
        public static Tracker getInstance
        {
            get
            {
                if(null == _instance)
                    _instance = new Tracker();
                return _instance;
            }
        }

        public void init(string idGame, string path = "", SerializerType type = SerializerType.NONE)
        {
            idGame_ = idGame;
            idSession_ = GenerateID();
            ISerializer s = null;

            if (path != "")
            {
                switch (type)
                {
                    case SerializerType.JSON:
                        s = new JsonSerializer();
                        break;
                    default:
                        break;
                }
                if(s != null)
                    persistence_ = new FilePersistence(s, path);
                else
                    throw new Exception("ERROR AL INICIALIZAR");
            }

            addTrackerEvent(EventType.SESSION_START);
        }

        public void end()
        {
            addTrackerEvent(EventType.SESSION_END);
            flush();
            activeTrackers_.Clear();
        }

        public void addTrackerEvent(EventType eventType_, string[] args = null)
        {
            TrackerEvent e = null;
            switch (eventType_)
            {
                case EventType.SESSION_START:
                    e = new StartSession();
                    break;
                case EventType.LEVEL_START:
                    e = new StartLevel(args[0]);
                    break;
                case EventType.LEVEL_END:
                    e = new EndLevel();
                    break;
                case EventType.SESSION_END:
                    e = new EndSession();
                    break;
                case EventType.PLAYER_HIT:
                    e = new PlayerHit(float.Parse(args[0]), float.Parse(args[1]));
                    break;
                case EventType.ENEMY_MAKES_DAMAGE:
                    e = new EnemyMakesDamage(args[0]);
                    break;
                case EventType.WEAPON_CHANGE:
                    e = new WeaponChange(args[0]);
                    break;
                case EventType.WEAPON_SHOT_RESULT:
                    e = new WeaponShotResult(args[0], bool.Parse(args[1]));
                    break;
                default:
                    break;
            }


            if (e != null)
            {
                e.setID(idGame_, idSession_);
                foreach (ITrackerAsset T in activeTrackers_)
                {
                    if (T.accept(e))
                    {
                        persistence_.send(e);
                        if (eventType_ == EventType.LEVEL_END)
                            flush();
                        break;
                    }
                }
            }
        }

        public void flush()
        {
            persistence_.flush();
        }

        private string GenerateID()
        {
            char[] c = { 'B', 'b', 'D', 'd', 'N', 'n', 'P', 'p' };
            int index = new Random().Next(0, c.Length - 1);
            string s = c[index].ToString();
            return Guid.NewGuid().ToString(s);
        }

        public void AddTracker(TrackersType TT)
        {
            switch (TT)
            {
                case TrackersType.BTR_TRACKER:
                    activeTrackers_.Add(new BTR_Tracker());
                    break;
                default:
                    break;
            }
        }

        public void ChangeFilePath(string path)
        {
            persistence_.newFilePath(path);
        }
    }
}
