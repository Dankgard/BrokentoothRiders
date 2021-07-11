using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace TrackerSpace
{
    class FilePersistence : IPersistence
    {

        private string path;

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

            string filePath = path + serializer_.getExtension();
            if (File.Exists(filePath))
            {
                string temp = File.ReadAllText(filePath);
                temp += inf;
                File.WriteAllText(filePath, temp);
            }
            else
                File.WriteAllText(filePath, inf);

            clearEvents();
        }

        public override void send(TrackerEvent e)
        {
            events.Enqueue(e);
        }

        public override void newFilePath(string filePath)
        {
            path = filePath;
        }
    }
}
