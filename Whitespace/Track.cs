using System;

namespace Whitespace
{
    public class Track : ITrack
    {
        readonly string _title;

        readonly ISession _morningSession;
        readonly ISession _afternoonSession;

        public Track(ISessionFactory sessionFactory, 
            string title, 
            DateTime morningStartTimeHours, 
            DateTime morningEndTimeHours, 
            DateTime afternoonStartTimeHours, 
            DateTime afternoonEndTimeHours)
        {
            _title = title;
            _morningSession = sessionFactory.Create(morningStartTimeHours, morningEndTimeHours);
            _afternoonSession = sessionFactory.Create(afternoonStartTimeHours, afternoonEndTimeHours);
        }

        public ISession AfternoonSession
        {
            get
            {
                return _afternoonSession;
            }
        }
        public TimeSpan AvailableCapacity
        {
            get
            {
                return MorningAvailableCapacity.Add(AfternoonAvailableCapacity);
            }
        }
        public int AvailableCapacityMins
        {
            get
            {
                return (int)AvailableCapacity.TotalMinutes;
            }
        }
        public TimeSpan MorningAvailableCapacity
        {
            get
            {
                return _morningSession.AvailableCapacity;
            }
        }
        public TimeSpan AfternoonAvailableCapacity
        {
            get
            {
                return _afternoonSession.AvailableCapacity;
            }
        }
        public int MorningAvailableCapacityMins
        {
            get
            {
                return (int)MorningAvailableCapacity.TotalMinutes;
            }
        }
        public int AfternoonAvailableCapacityMins
        {
            get
            {
                return (int)AfternoonAvailableCapacity.TotalMinutes;
            }
        }
        public string Identifier
        {
            get
            {
                return _title;
            }
        }
        public TimeSpan MaxAvailableCapacity
        {
            get
            {
                return new TimeSpan(0, MaxAvailableCapacityMins, 0);
            }
        }
        public int MaxAvailableCapacityMins
        {
            get
            {
                return Math.Max(MorningAvailableCapacityMins, AfternoonAvailableCapacityMins);
            }
        }
        public ISession MorningSession
        {
            get
            {
                return _morningSession;
            }
        }

        public TimeSpan AfternoonScheduledCapacity { get { return _afternoonSession.ScheduledCapacity; } }
        public int AfternoonScheduledCapacityMins { get { return _afternoonSession.ScheduledCapacityMins; } }
        public TimeSpan MorningScheduledCapacity { get { return _morningSession.ScheduledCapacity; } }
        public int MorningScheduledCapacityMins { get { return _morningSession.ScheduledCapacityMins; } }
        public TimeSpan ScheduledCapacity { get { return new TimeSpan(0, ScheduledCapacityMins, 0); } }
        public int ScheduledCapacityMins { get { return MorningScheduledCapacityMins + AfternoonScheduledCapacityMins; } }

        public bool ScheduleEventMostCapacityOrMorningFirst(Event evnt)
        {
            // schedule where most available space exists, or in morning if same
            if (MorningAvailableCapacityMins >= AfternoonAvailableCapacityMins)
            {
                return ScheduleMorningEvent(evnt);
            }
            else
            {
                return ScheduleAfternoonEvent(evnt);
            }
        }
        public bool ScheduleEventLeastCapacityMorningFirst(Event evnt)
        {
            // schedule where least available space exists, or in morning if same
            if (MorningAvailableCapacityMins <= AfternoonAvailableCapacityMins && MorningAvailableCapacityMins >= evnt.DurationMins) // ???
            {
                return ScheduleMorningEvent(evnt);
            }
            else
            {
                return ScheduleAfternoonEvent(evnt);
            }
        }
        public bool ScheduleEventMorningFirst(Event evnt)
        {
            if (MorningAvailableCapacityMins >= evnt.DurationMins)
            {
                return ScheduleMorningEvent(evnt);
            }
            else
            {
                return ScheduleAfternoonEvent(evnt);
            }
        }
        public bool ScheduleEventAfternoonFirst(Event evnt)
        {
            if (AfternoonAvailableCapacityMins >= evnt.DurationMins)
            {
                return ScheduleAfternoonEvent(evnt);
            }
            else
            {
                return ScheduleMorningEvent(evnt);          
            }
        }
        public bool ScheduleEventBalancedCountFirst(Event evnt)
        {
            if(MorningSession.ScheduledEvents.Count <= AfternoonSession.ScheduledEvents.Count)
            {
                // try schedule morning else afternoon
                if (MorningAvailableCapacityMins >= evnt.DurationMins)
                {
                    return ScheduleMorningEvent(evnt);
                } 
                else
                {
                    return ScheduleAfternoonEvent(evnt);
                }
            }
            else
            {
                // try schedule afternoon else afternoon
                if (AfternoonAvailableCapacityMins >= evnt.DurationMins)
                {
                    return ScheduleAfternoonEvent(evnt);
                }
                else
                {
                    return ScheduleMorningEvent(evnt);
                }
            }
        }
        public bool ScheduleEventBalancedCount(Event evnt)
        {
            if (MorningSession.ScheduledEvents.Count <= AfternoonSession.ScheduledEvents.Count)
            {
                // try schedule morning else fail
                if (MorningAvailableCapacityMins >= evnt.DurationMins)
                {
                    return ScheduleMorningEvent(evnt);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // try schedule afternoon else fail
                if (AfternoonAvailableCapacityMins >= evnt.DurationMins)
                {
                    return ScheduleAfternoonEvent(evnt);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool ScheduleMorningEvent(Event evnt)
        {
            return _morningSession.CanScheduleEvent(evnt) && _morningSession.ScheduleEvent(evnt);
        }
        public bool ScheduleAfternoonEvent(Event evnt)
        {
            return _afternoonSession.CanScheduleEvent(evnt) && _afternoonSession.ScheduleEvent(evnt);
        }
    }
}
