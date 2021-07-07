using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartSession : TrackerEvent
    {
        public string session_id;
        public string sessionStartTime;

        public StartSession() : base(EventType.SESSION_START)
        {
            // Genera una identidad unica para la sesion
            session_id = GenerateID();

            // Registra la hora a la que se inicia la sesion
            DateTime startTime = DateTime.Now;
            sessionStartTime = startTime.ToString();
        }

        public string GenerateID()
        {
            char[] c = { 'B', 'b', 'D', 'd', 'N', 'n', 'P', 'p' };
            int index = new Random().Next(0, c.Length - 1);
            string s = c[index].ToString();
            return Guid.NewGuid().ToString(s);
        }

        public override void toJson(out string inf)
        {
            inf = JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
