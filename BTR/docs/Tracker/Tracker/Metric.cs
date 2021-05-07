using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Tracker
{
    /*public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
    }*/

    enum EventTracker
    {
        DAMAGE_FREQUENCY, HIT_FREQUENCY, LEVEL_TIME, WEAPON_USAGE_FREQUENCY, WEAPON_ACCURACY
    }
    /*public class Session
    {
        float startTime = 0.0f;
        Session sesion;
        string startMessage = "Inicio de sesion: ";

        public Session()
        {
            sesion = new();
        }

        public void Start()
        {
            string jsonFile = JsonConvert.SerializeObject(startTime, Formatting.Indented);
            File.WriteAllText("../Files/Session.json", jsonFile);
        }

        public void End()
        {

        }
    }
    public class Level {
            
    }*/


    
    /*public class DamageFrequency
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
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(path, jsonFile);
        }
    }*/
    /*public class HitFrequency
    {
        HitFrequency hitFrequency;
        public HitFrequency()
        {
            hitFrequency = new HitFrequency
            {
                Metric = "Hit Frequency",
                HitPerEnemy = new Dictionary<string, int>()
            };
        }
        public string Metric { get; set; }
        public int Level { get; set; }
        public Dictionary<string, int> HitPerEnemy;
        public void AddEntry(string enemyType)
        {
            if (hitFrequency.HitPerEnemy.ContainsKey(enemyType))
            {
                hitFrequency.HitPerEnemy[enemyType]++;
            }
            else
            {
                hitFrequency.HitPerEnemy.Add(enemyType, 1);
            }
        }
        public void ToJson()
        {
            string jsonFile = JsonConvert.SerializeObject(hitFrequency, Formatting.Indented);
            File.WriteAllText("../Files/HitFrequency.json", jsonFile);
        }
    }*/
    /*public class LevelTime
    {
        LevelTime levelTime;
        public LevelTime()
        {
            levelTime = new LevelTime
            {
                Metric = "Level Time",
                Time = 0
            };
        }
        public string Metric { get; set; }
        public float Time { get; set; }

        public void StartTimer(float startTimer)
        {
            levelTime.Time = startTimer;
        }

        public void StopTimer(float FinalTimer)
        {
            levelTime.Time = FinalTimer - levelTime.Time;
        }
        public void ToJson()
        {
            string jsonFile = JsonConvert.SerializeObject(levelTime, Formatting.Indented);
            File.WriteAllText("../Files/LevelTime.json", jsonFile);
        }
    }*/
    /*public class WeaponUsageFrequency
    {
        WeaponUsageFrequency weaponUsageFrequency;
        public WeaponUsageFrequency()
        {
            weaponUsageFrequency = new WeaponUsageFrequency();
            Metric = "Weapon Usage Frequency";
            WeaponUsage = new Dictionary<string, float>();
        }
        public string Metric { get; set; }
        public int Level { get; set; }
        public Dictionary<string, float> WeaponUsage;

        //el tiempo que recibe en el parametro timeUsed se controla desde unity
        public void AddEntry(string gunType, float timeUsed)
        {
            if (weaponUsageFrequency.WeaponUsage.ContainsKey(gunType))
            {
                weaponUsageFrequency.WeaponUsage[gunType] += timeUsed;
            }
            else
            {
                weaponUsageFrequency.WeaponUsage.Add(gunType, timeUsed);
            }
        }
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(weaponUsageFrequency, Formatting.Indented);
            File.WriteAllText(path, jsonFile);
        }
    }*/
    /*public class WeaponAccuracy
    {
        WeaponAccuracy weaponAccuracy;

        public WeaponAccuracy()
        {
            weaponAccuracy = new WeaponAccuracy();
            Metric = "Weapon Accuracy";
            WeaponHit = new Dictionary<string, float>();
            WeaponMiss = new Dictionary<string, float>();
            WeaponAccuracyPercentage = new Dictionary<string, float>();
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
                if (weaponAccuracy.WeaponHit.ContainsKey(gunType))
                    weaponAccuracy.WeaponHit[gunType]++;
                else weaponAccuracy.WeaponHit.Add(gunType, 1);
            }
            else
            {
                if (weaponAccuracy.WeaponMiss.ContainsKey(gunType))
                    WeaponMiss[gunType]++;
                else weaponAccuracy.WeaponMiss.Add(gunType, 1);
            }
        }
        public void CalculateAccuracy()
        {
            foreach (KeyValuePair<string, float> entry in WeaponHit)
            {
                if (weaponAccuracy.WeaponAccuracyPercentage.ContainsKey(entry.Key))
                    weaponAccuracy.WeaponAccuracyPercentage[entry.Key] =
                        weaponAccuracy.WeaponHit[entry.Key] / (weaponAccuracy.WeaponHit[entry.Key] + weaponAccuracy.WeaponMiss[entry.Key]);
                else
                    weaponAccuracy.WeaponAccuracyPercentage.Add(entry.Key,
                        weaponAccuracy.WeaponHit[entry.Key] / (weaponAccuracy.WeaponHit[entry.Key] + weaponAccuracy.WeaponMiss[entry.Key]));
            }
        }
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(weaponAccuracy, Formatting.Indented);
            File.WriteAllText(path, jsonFile);
        }
    }*/
}
