using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tracker
{
    public abstract class ITrackerAsset
    {
        public abstract bool accept(TrackerEvent e);
    }
}
