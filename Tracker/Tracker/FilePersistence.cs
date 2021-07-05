using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Tracker
{
    class FilePersistence : IPersistence
    {

        string path;

        public FilePersistence(ISerializer s, string path) : base(s)
        {
            this.path = path;
        }

        public override void flush()
        {
            string inf = "";
            foreach (TrackerEvent e in events)
            {
                inf += serializer_.serialize(e);
            }

            if (File.Exists(path))
            {
                string temp = File.ReadAllText(path);
                temp += inf;
                File.WriteAllText(path, temp);
            }
            else
                File.WriteAllText(path, inf);

            clearEvents();
        }

        public override void send(TrackerEvent e)
        {
            events.Enqueue(e);
        }
    }
}
