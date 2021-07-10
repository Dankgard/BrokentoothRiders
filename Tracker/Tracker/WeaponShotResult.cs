using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class WeaponShotResult : TrackerEvent
    {
        public string gunType;
        public string result;
        public WeaponShotResult(string gunType_, bool hit) : base(EventType.WEAPON_SHOT_RESULT)
        {
            gunType = gunType_;
            if (hit)
                result = "HIT";
            else
                result = "MISS";
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
