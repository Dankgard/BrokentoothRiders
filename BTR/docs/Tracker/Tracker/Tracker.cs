using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    class Tracker
    {
        private bool trackerActive { get; }
        private string levelId { get; }
        private string sessionId { get; }

        public List<Tracker> trackers { get; }

        public Tracker()
        {
            trackers = new List<Tracker>();
        }

        public void GetNewId(string id_)
        {
            Random hash = new Random();
            id_ = hash.ToString();
        }

        public void Init(string levelId_)
        {

        }
    }
}
