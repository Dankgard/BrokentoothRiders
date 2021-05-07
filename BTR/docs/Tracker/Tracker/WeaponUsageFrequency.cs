using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class WeaponUsageFrequency : Event
    {
        public WeaponUsageFrequency()
        {
            event_type = "Weapon Usage Frequency";
            WeaponUsage = new Dictionary<string, float>();
        }
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
        public override void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile;
            }
            File.WriteAllText(path, jsonFile);
        }
    }
}
