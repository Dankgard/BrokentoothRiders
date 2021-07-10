using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class EnemyMakesDamage : TrackerEvent
    {
        public string enemyType;
        public EnemyMakesDamage(string enemyType_) : base(EventType.ENEMY_MAKES_DAMAGE)
        {
            enemyType = enemyType_;
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
