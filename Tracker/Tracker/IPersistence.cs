using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TrackerSpace
{
    abstract class IPersistence
    {
        public ISerializer serializer_ = null;
        public Queue<TrackerEvent> events = new Queue<TrackerEvent>();

        protected IPersistence(ISerializer serializer)
        {
            serializer_ = serializer;
        }

        public abstract void send(TrackerEvent e);
        public abstract void flush();

        public void setSerializer(ISerializer s)
        {
            serializer_ = s;
        }

        public void clearEvents()
        {
            events.Clear();
        }
        public abstract void newFilePath(string filePath);
    }
}
