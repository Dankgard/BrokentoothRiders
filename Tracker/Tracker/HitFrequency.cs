using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class HitFrequency : TrackerEvent
    {
        public HitFrequency() : base(EventType.HIT_FREQUENCY)
        {
            HitPerEnemy = new Dictionary<string, int>();
        }

        public Dictionary<string, int> HitPerEnemy;

        public void AddEntry(string enemyType)
        {
            if (HitPerEnemy.ContainsKey(enemyType))
            {
                HitPerEnemy[enemyType]++;
            }
            else
            {
                HitPerEnemy.Add(enemyType, 1);
            }
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
