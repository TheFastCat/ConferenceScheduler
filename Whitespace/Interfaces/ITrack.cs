using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitespace
{
    public interface ITrack
    {
        ISession AfternoonSession { get; }
        TimeSpan AfternoonAvailableCapacity { get; }
        int AfternoonAvailableCapacityMins { get; }
        TimeSpan AfternoonScheduledCapacity { get; }
        int AfternoonScheduledCapacityMins { get; }
        TimeSpan AvailableCapacity { get; }
        int AvailableCapacityMins { get; }
        string Identifier { get; }
        TimeSpan MaxAvailableCapacity { get; }
        int MaxAvailableCapacityMins { get; }
        ISession MorningSession { get; }
        TimeSpan MorningAvailableCapacity { get; }
        int MorningAvailableCapacityMins { get; }
        TimeSpan MorningScheduledCapacity { get; }
        int MorningScheduledCapacityMins { get; }
        TimeSpan ScheduledCapacity { get; }
        int ScheduledCapacityMins { get; }

        bool ScheduleAfternoonEvent(Event evnt);
        bool ScheduleEventMostCapacityOrMorningFirst(Event evnt);
        bool ScheduleEventLeastCapacityMorningFirst(Event evnt);
        bool ScheduleEventMorningFirst(Event evnt);
        bool ScheduleEventAfternoonFirst(Event evnt);
        bool ScheduleMorningEvent(Event evnt);
        bool ScheduleEventBalancedCountFirst(Event evnt);
        bool ScheduleEventBalancedCount(Event evnt);
    }
}
