using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    public abstract class ISerializer
    {
        public abstract string serialize(TrackerEvent e);
        public abstract string getExtension();
    }
}
