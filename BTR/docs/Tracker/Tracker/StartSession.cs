﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class StartSession : Event
    {
        private string session_id;
        private string sessionStartTime;

        public StartSession()
        {
            event_type = "Start_Session";

            // Genera una identidad unica para la sesion
            Random id = new Random();
            sessionId = id.ToString();
            // Registra la hora a la que se inicia la sesion
            DateTime startTime = DateTime.Now;
            sessionStartTime = startTime.ToString();
        }

        public override void ToJson(string path)
        {
            jsonFileData = JsonConvert.SerializeObject(this, Formatting.Indented);
            // Si el fichero existe
            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += jsonFileData;
            }
            File.WriteAllText(path, jsonFileData);
        }
    }
}
