using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class JsonSerializer : ISerializer
    {
        public override string getExtension()
        {
            return ".json";
        }

        //AQUI SE RECOGE LA INFORMACION DEL EVENTO EN UN STRING QUE LUEGO SE AÑADIRA AL JSON
        public override string serialize(TrackerEvent e) {
            string jsonFile;
            e.toJson(out jsonFile);
            return jsonFile;
        }
    }
}
