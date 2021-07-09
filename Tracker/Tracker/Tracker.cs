using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    class Tracker
    {
        private readonly static Tracker _instance = new Tracker();
        IPersistence persistence_;
        List<ITrackerAsset> activeTrackers_;

        public enum TrackersType
        {
            BTR_TRACKER
        }

        public enum SerializerType
        {
            JSON, NONE
        }

        string idGame_;
        string idSession_;

        private Tracker() { }
        public static Tracker getInstance
        {
            get{ return _instance; }
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

            trackerEvent(new StartSession());
        }

        public void end()
        {
            trackerEvent(new EndSession());
            flush();
            activeTrackers_.Clear();
        }

        public void trackerEvent(TrackerEvent e)
        {            
            foreach (ITrackerAsset T in activeTrackers_)
            {
                if (T.accept(e))
                {
                    persistence_.send(e);
                    break;
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
    }
}
