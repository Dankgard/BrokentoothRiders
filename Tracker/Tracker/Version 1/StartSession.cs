using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartSession : Event
    {
        public string session_id;
        public string sessionStartTime;

        public StartSession()
        {
            Event_type = "Start_Session";

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

        public void ToJson(string path)
        {
            string jsonFile = JsonConvert.SerializeObject(this, Formatting.Indented);
            // Si el fichero existe
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFile + "\n";
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, jsonFile);
        }
    }
}
