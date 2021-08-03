using System;
using System.Collections.Generic;
using System.Linq;

namespace Whitespace
{
    public class EventListFacade : IEventListFacade
    {
        readonly List<Event> _events;

        public EventListFacade(IEnumerable<Event> events)
        {
            _events = new List<Event>(events);
        }

        public int EventCount
        {
            get
            {
                return _events.Count;
            }
        }
        public List<int> DistintDurations
        {
            get
            {
                return _events.Select(evnt => evnt.DurationMins).Distinct().ToList();
            }
        }
        public Dictionary<int, Queue<Event>> DurationEventDictionary
        {
            get
            {
                Dictionary<int, Queue<Event>> durationEventDictionary = new();

                foreach (Event evnt in _events)
                {
                    if (durationEventDictionary.ContainsKey(evnt.DurationMins))
                    {
                        Queue<Event> eventsForDuration = durationEventDictionary[evnt.DurationMins];
                        eventsForDuration.Enqueue(evnt);
                    }
                    else
                    {
                        Queue<Event> eventsForDuration = new();
                        eventsForDuration.Enqueue(evnt);
                        durationEventDictionary.Add(evnt.DurationMins, eventsForDuration);
                    }
                }

                return durationEventDictionary;
            }
        }
        public List<Event> Events { get { return _events; } }
        public TimeSpan MaxDuration
        {
            get { return new TimeSpan(0, _events.Max(evnt => evnt.DurationMins), 0); }
        }
        public int MaxDurationMins
        {
            get { return _events.Max(evnt => evnt.DurationMins); }
        }
        public TimeSpan MinDuration
        {
            get { return new TimeSpan(0, _events.Min(evnt => evnt.DurationMins), 0); }
        }
        public int MinDurationMins
        {
            get { return _events.Min(evnt => evnt.DurationMins); }
        }
        public int TotalDurationMins
        {
            get
            {
                return _events.Sum(evnt => evnt.DurationMins);
            }
        }
        public TimeSpan TotalDuration
        {
            get
            {
                return new TimeSpan(0, TotalDurationMins, 0);
            }
        }

        public int CountForDuration(TimeSpan duration)
        {
            return CountForDuration((int)duration.TotalMinutes);
        }
        public int CountForDuration(int durationMins)
        {
            return _events.Where(evnt => evnt.DurationMins == durationMins).Count();
        }
        public bool ExistsWithDuration(TimeSpan duration)
        {
            return ExistsWithDuration((int)duration.TotalMinutes);
        }
        public bool ExistsWithDuration(int durationMins)
        {
            return _events.Exists(evnt => evnt.DurationMins == durationMins);
        }

        public TimeSpan MaxDurationForAvailable(TimeSpan duration)
        {
            return _events.Exists(evnt => evnt.Duration <= duration) ? _events.Where(evnt => evnt.Duration <= duration).Max(evnt => evnt.Duration) : new TimeSpan(0, 0, 0);
        }
        public int MaxDurationForCeilingMins(int availableDurationMins)
        {
            return (int)MaxDurationForAvailable(new TimeSpan(0, availableDurationMins, 0)).TotalMinutes;
        }

        public Event PopForDuration(TimeSpan duration)
        {
            return PopForDuration((int)duration.TotalMinutes);
        }
        public Event PopForDuration(int durationMins)
        {
            if (!ExistsWithDuration(durationMins))
            {
                return null;
            }

            Event forDuration = _events.First(evnt => evnt.DurationMins == durationMins);
            _events.RemoveAt(_events.IndexOf(forDuration));
            return forDuration;
        }
        public Event PopMaxDuration()
        {
            return PopForDuration(MaxDuration);
        }
        public Event PopMinDuration()
        {
            return PopForDuration(MinDuration);
        }

        public int TracksRequiredToSchedule(int trackDurationMins)
        {
            return TotalDurationMins % trackDurationMins == 0 ? TotalDurationMins / trackDurationMins : TotalDurationMins / trackDurationMins + 1;
        }
    }
}
