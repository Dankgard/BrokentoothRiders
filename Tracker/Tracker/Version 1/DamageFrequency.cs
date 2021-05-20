using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class DamageFrequency : Event
    {
        public DamageFrequency()
        {
            Event_type = "Damage_Frequency";
            Positions = new List<Vector2>();
        }
        public List<Vector2> Positions;

        public void AddPosition(float posX, float posY)
        {
            Positions.Add(new Vector2 { X = posX, Y = posY });
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
