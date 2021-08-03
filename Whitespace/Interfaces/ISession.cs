using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface ISession
    {
        TimeSpan AvailableCapacity { get; }
        int AvailableCapactiyMins { get; }
        DateTime EndTime { get; }
        string EndTimeString { get; }
        public DateTime NextNextAvailableStartTime { get; }
        TimeSpan ScheduledCapacity { get; }
        int ScheduledCapacityMins { get; }
        List<Event> ScheduledEvents { get; }
        DateTime StartTime { get; }
        string StartTimeString { get; }

        bool CanScheduleEvent(Event evnt);
        bool ForceEventScheduleAtTime(Event evnt, bool forceTime = false);
        bool ScheduleEvent(Event evnt, bool ignoreConstraints = false);
    }
}
