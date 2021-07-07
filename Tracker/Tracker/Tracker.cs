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

        string idGame_;
        string idSession_;

        private Tracker() { }
        public static Tracker getInstance
        {
            get{ return _instance; }
        }

        public void init(string idGame)
        {
            idGame_ = idGame;
            idSession_ = GenerateID();

            trackerEvent(new StartSession());
        }

        public void end()
        {
            trackerEvent(new EndSession());
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
