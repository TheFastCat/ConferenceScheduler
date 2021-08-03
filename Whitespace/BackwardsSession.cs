using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Whitespace
{
    public class BackwardsSession : ISession
    {
        readonly List<Event> _scheduledEvents = new();

        readonly DateTime _startTime;
        readonly DateTime _endTime;

        DateTime _nextAvailableStartTime;
        TimeSpan _remainingAvailableDuration;

        public BackwardsSession(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
            _nextAvailableStartTime = _endTime;
            _remainingAvailableDuration = endTime.Subtract(startTime);
        }

        public bool CanScheduleEvent(Event evnt)
        {
            return _remainingAvailableDuration >= evnt.Duration;
        }
        public bool ForceEventScheduleAtTime(Event evnt, bool forceTime = false)
        {
            if (forceTime && evnt.StartTime == null)
                return false;

            if (!forceTime)
            {
                _nextAvailableStartTime = _nextAvailableStartTime.Subtract(evnt.Duration);
                evnt.StartTime = _nextAvailableStartTime;
            }

            evnt.EndTime = evnt.StartTime.Value.Add(evnt.Duration);
            _scheduledEvents.Add(evnt);
            return true;
        }
        public bool ScheduleEvent(Event evnt, bool ignoreConstraints = false)
        {
            if (ignoreConstraints || CanScheduleEvent(evnt))
            {
                _nextAvailableStartTime = _nextAvailableStartTime.Subtract(evnt.Duration);
                evnt.StartTime = _nextAvailableStartTime;
                evnt.EndTime = evnt.StartTime.Value.Add(evnt.Duration);
                _remainingAvailableDuration -= evnt.Duration;
                _scheduledEvents.Add(evnt);
                return true;
            }

            return false;
        }

        public TimeSpan AvailableCapacity { get { return _remainingAvailableDuration; } }
        public int AvailableCapactiyMins { get { return (int)_remainingAvailableDuration.TotalMinutes; } }
        public DateTime EndTime { get { return _endTime; } }
        public string EndTimeString { get { return _endTime.ToString("t", new CultureInfo("en-US")); } }
        public DateTime NextNextAvailableStartTime { get { return _nextAvailableStartTime; } }
        public TimeSpan ScheduledCapacity { get { return new TimeSpan(0, ScheduledCapacityMins, 0); } }
        public List<Event> ScheduledEvents { get { return _scheduledEvents; } }
        public int ScheduledCapacityMins { get { return _scheduledEvents.Sum(evnt => evnt.DurationMins); } }
        public DateTime StartTime { get { return _startTime; } }
        public string StartTimeString { get { return _startTime.ToString("t", new CultureInfo("en-US")); } }
    }
}
