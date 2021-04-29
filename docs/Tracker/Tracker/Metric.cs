using System.Collections.Generic;

namespace Tracker
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class DamageFrequency
    {
        public DamageFrequency()
        {
            Metric = "Damage Frequency";
            Positions = new List<Vector2>();
        }
        public string Metric { get; set; }
        public int Level { get; set; }
        public List<Vector2> Positions;

        public void AddPosition(float posX, float posY)
        {
            Positions.Add(new Vector2 { X = posX, Y = posY });
        }
    }
    public class HitFrequency
    {
        public HitFrequency()
        {
            Metric = "Hit Frequency";
            HitPerEnemy = new();
        }
        public string Metric { get; set; }
        public int Level { get; set; }
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
    }
    public class LevelTime
    {
        public LevelTime(float InitialTimer)
        {
            Metric = "Level Time";
            Time = InitialTimer;
        }
        public string Metric { get; set; }
        public float Time { get; set; }

        public void StopTimer(float FinalTimer)
        {
            Time = FinalTimer - Time;
        }
    }
    public class WeaponUsageFrequency
    {
        public WeaponUsageFrequency()
        {
            Metric = "Weapon Usage Frequency";
            WeaponUsage = new();
        }
        public string Metric { get; set; }
        public int Level { get; set; }
        public Dictionary<string, float> WeaponUsage;

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
    }
    public class WeaponAccuracy
    {
        public WeaponAccuracy()
        {
            Metric = "Weapon Accuracy";
            WeaponHit = new();
            WeaponMiss = new();
            WeaponAccuracyPercentage = new();
        }
        public string Metric { get; set; }
        public int Level { get; set; }        
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
                    WeaponAccuracyPercentage[entry.Key] = WeaponHit[entry.Key] / (WeaponHit[entry.Key] + WeaponMiss[entry.Key]);
                else WeaponAccuracyPercentage.Add(entry.Key, WeaponHit[entry.Key] / (WeaponHit[entry.Key] + WeaponMiss[entry.Key]));
            }
        }
    }

}
