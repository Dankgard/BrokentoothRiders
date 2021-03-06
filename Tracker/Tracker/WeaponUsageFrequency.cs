﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class WeaponUsageFrequency : Event
    {
        public Dictionary<string, float> WeaponUsage;

        public WeaponUsageFrequency()
        {
            Event_type = "Weapon_Usage_Frequency";
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
        public override void ToJson(string path)
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
