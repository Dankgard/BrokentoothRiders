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

    public class DamageFrequency : TrackerEvent
    {
        public DamageFrequency() : base(EventType.DAMAGE_FREQUENCY)
        {            
        }
        public List<Vector2> Positions;

        public void AddPosition(float posX, float posY)
        {
            Positions.Add(new Vector2 { X = posX, Y = posY });
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
