using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    class PlayerHit : TrackerEvent
    {
        public Vector2 Positions;

        public PlayerHit(float posX, float posY) : base(EventType.PLAYER_HIT)
        {
            Positions = new Vector2 { X = posX, Y = posY };
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
