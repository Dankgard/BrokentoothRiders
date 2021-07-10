using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class WeaponChange : TrackerEvent
    {
        public string gunType;

        public WeaponChange(string gunType_) : base(EventType.WEAPON_CHANGE)
        {
            gunType = gunType_;
        }
        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
