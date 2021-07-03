using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class WeaponUsageFrequency : TrackerEvent
    {
        public Dictionary<string, float> WeaponUsage;

        public WeaponUsageFrequency() : base(EventType.HIT_FREQUENCY)
        {
            WeaponUsage = new Dictionary<string, float>();
        }

        //el tiempo que recibe en el parametro timeUsed se controla desde unity
        public void AddEntry(string gunType, float timeUsed)
        {
            if (WeaponUsage.ContainsKey(gunType))
            {
                WeaponUsage[gunType] += timeUsed;
            }
            else
            {
                WeaponUsage.Add(gunType, timeUsed);
            }
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
