
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class LevelTime : TrackerEvent
    {
        public float iniTime;
        public float totalTime;
        public LevelTime() : base(EventType.HIT_FREQUENCY)
        {
        }

        public void StartTimer(float iniTime_)
        {
            iniTime = iniTime_;
        }

        public void TotalTime(float endTime)
        {
            totalTime = endTime - iniTime;
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
