using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class HitFrequency : Event
    {
        public HitFrequency()
        {
            Event_type = "Hit_Frequency";
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
        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile;
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, jsonFile);
        }
    }
}
