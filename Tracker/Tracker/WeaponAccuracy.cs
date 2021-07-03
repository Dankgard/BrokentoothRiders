using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class WeaponAccuracy : TrackerEvent
    {
        public WeaponAccuracy() : base(EventType.HIT_FREQUENCY)
        {
            WeaponHit = new Dictionary<string, float>();
            WeaponMiss = new Dictionary<string, float>();
            WeaponAccuracyPercentage = new Dictionary<string, float>();
        }

        public Dictionary<string, float> WeaponHit;
        public Dictionary<string, float> WeaponMiss;
        public Dictionary<string, float> WeaponAccuracyPercentage;

        public void AddHitEntry(string gunType, bool hit)
        {
            if (hit)
            {
                if (WeaponHit.ContainsKey(gunType))
                    WeaponHit[gunType]++;
                else WeaponHit.Add(gunType, 1);
            }
            else
            {
                if (WeaponMiss.ContainsKey(gunType))
                    WeaponMiss[gunType]++;
                else WeaponMiss.Add(gunType, 1);
            }
        }
        public void CalculateAccuracy()
        {
            foreach (KeyValuePair<string, float> entry in WeaponHit)
            {
                if (WeaponAccuracyPercentage.ContainsKey(entry.Key))
                {
                    WeaponAccuracyPercentage[entry.Key] =
                        WeaponHit[entry.Key] / (WeaponHit[entry.Key] + WeaponMiss[entry.Key]);
                }
                else
                {
                    WeaponAccuracyPercentage.Add(entry.Key,
                        WeaponHit[entry.Key] / (WeaponHit[entry.Key] + WeaponMiss[entry.Key]));
                }
            }
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
