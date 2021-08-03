using System;
using System.Collections.Generic;
using Xunit;
using Whitespace;
using System.Linq;

namespace WhitespaceTest
{
    public class EventListFacadeTests : TestBase
    {
        [Fact]
        public void Constructor()
        {
            EventListFacade eventListFacade = new(_events1);
            Assert.NotNull(eventListFacade);

            eventListFacade = new EventListFacade(new List<Event>());
            Assert.NotNull(eventListFacade);
        }

        [Fact]
        public void EventCount()
        {
            Assert.Equal(_events1.Count, _eventListFacade1.EventCount);

            EventListFacade eventQueue = new(new List<Event>());
            Assert.Equal(0, eventQueue.EventCount);
        }

        [Fact]
        public void TotalDuration()
        {
            Assert.Equal(new TimeSpan(0, _events1.Sum(evnt => evnt.DurationMins),0), _eventListFacade1.TotalDuration);

            EventListFacade eventListFacade = new(new List<Event>());
            Assert.Equal(_0mins, eventListFacade.TotalDuration);
        }

        [Fact]
        public void TotalDurationMins()
        {
            Assert.Equal(_events1.Sum(evnt=> evnt.DurationMins), _eventListFacade1.TotalDurationMins);

            EventListFacade eventListFacade = new(new List<Event>());
            Assert.Equal(_0, eventListFacade.TotalDurationMins);
        }

        [Fact]
        public void MaxDuration()
        {
            Assert.Equal(new TimeSpan(0, _events1.Max(evnt => evnt.DurationMins),0), _eventListFacade1.MaxDuration);
            Assert.Equal(_60mins, _eventListFacade1.MaxDuration);
        }

        [Fact]
        public void MaxDurationMins()
        {
            Assert.Equal(_events1.Max(evnt => evnt.DurationMins), _eventListFacade1.MaxDurationMins);
            Assert.Equal(_60, _eventListFacade1.MaxDurationMins);
        }

        [Fact]
        public void MinDuration()
        {
            Assert.Equal(new TimeSpan(0, _events1.Min(evnt => evnt.DurationMins), 0), _eventListFacade1.MinDuration);
            Assert.Equal(_5mins, _eventListFacade1.MinDuration);
        }

        [Fact]
        public void MinDurationMins()
        {
            Assert.Equal(_events1.Min(evnt => evnt.DurationMins), _eventListFacade1.MinDurationMins);
            Assert.Equal(_5, _eventListFacade1.MinDurationMins);
        }

        [Fact]
        public void DistinctDurations()
        {
            List<int> distinctDurationMins = _eventListFacade1.DistintDurations;
            Assert.Equal(4, distinctDurationMins.Count);
            distinctDurationMins.ForEach(durationMins => Assert.True(_eventListFacade1.ExistsWithDuration(durationMins)));
        }

        [Fact]
        public void CountForDuration()
        {
            _eventListFacade1 = new EventListFacade(new List<Event>());
            Assert.Equal(0, _eventListFacade1.CountForDuration(_30mins.Minutes));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event30min });
            Assert.Equal(1, _eventListFacade1.CountForDuration(_30mins.Minutes));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event30min, _event30min });
            Assert.Equal(2, _eventListFacade1.CountForDuration(_30mins.Minutes));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event15min, _event30min, _event30min, _event45min });
            Assert.Equal(2, _eventListFacade1.CountForDuration(_30mins.Minutes));

            _eventListFacade1 = new EventListFacade(new List<Event>());
            Assert.Equal(0, _eventListFacade1.CountForDuration(_30mins));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event30min });
            Assert.Equal(1, _eventListFacade1.CountForDuration(_30mins));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event30min, _event30min });
            Assert.Equal(2, _eventListFacade1.CountForDuration(_30mins));
            _eventListFacade1 = new EventListFacade(new List<Event>() { _event15min, _event30min, _event30min, _event45min });
            Assert.Equal(2, _eventListFacade1.CountForDuration(_30mins));
        }

        [Fact]
        public void ExistsWithDuration()
        {
            _eventListFacade1 = new EventListFacade(new List<Event>());
            Assert.False(_eventListFacade1.ExistsWithDuration(180));

            _eventListFacade1 = new EventListFacade(new List<Event>() { _event180min });
            Assert.True(_eventListFacade1.ExistsWithDuration(180));

            _eventListFacade1.PopMaxDuration();
            Assert.False(_eventListFacade1.ExistsWithDuration(180));

            _eventListFacade1 = new EventListFacade(new List<Event>());
            Assert.False(_eventListFacade1.ExistsWithDuration(new TimeSpan(0, 180, 0)));

            _eventListFacade1 = new EventListFacade(new List<Event>() { _event180min });
            Assert.True(_eventListFacade1.ExistsWithDuration(new TimeSpan(0, 180, 0)));

            _eventListFacade1.PopMaxDuration();
            Assert.False(_eventListFacade1.ExistsWithDuration(new TimeSpan(0, 180, 0)));
        }

        [Fact]
        public void PopMaxDuration()
        {
            int startingMins       = _eventListFacade1.TotalDurationMins;
            int startingEventCount = _eventListFacade1.EventCount;
            Assert.Equal(_events1.Max(evnt => evnt.DurationMins), _eventListFacade1.PopMaxDuration().DurationMins);
            Assert.Equal(startingEventCount - _1, _eventListFacade1.EventCount);
            Assert.Equal(startingMins - _60,  _eventListFacade1.TotalDurationMins);
        }

        [Fact]
        public void PopMinDuration()
        {
            int startingMins = _eventListFacade1.TotalDurationMins;
            Assert.Equal(5, _eventListFacade1.PopMinDuration().DurationMins);
            Assert.Equal(_events1.Count - _1, _eventListFacade1.EventCount);
            Assert.Equal(startingMins - _5, _eventListFacade1.TotalDurationMins);
        }

        [Fact]
        public void PopForDuration1()
        {
            int countEvents = _eventListFacade1.EventCount;
            Event event30min = _eventListFacade1.PopForDuration(_30mins.Minutes);
            Assert.NotNull(event30min);
            Assert.Equal(_30mins, event30min.Duration);
            Assert.Equal(--countEvents, _eventListFacade1.EventCount);
        }

        [Fact]
        public void PopForDuration2() 
        {
            int countEvents = _eventListFacade1.EventCount;
            Assert.True(_eventListFacade1.ExistsWithDuration(_60mins));
            Event event60min = _eventListFacade1.PopForDuration(_60);
            Assert.NotNull(event60min);
            Assert.Equal(_60mins, event60min.Duration);
            Assert.Equal(--countEvents, _eventListFacade1.EventCount);
        }

        [Fact]
        public void PopForDuration3()
        {
            int countEvents = _eventListFacade1.EventCount;
            Assert.True(_eventListFacade1.ExistsWithDuration(_30mins));
            Event event30min = _eventListFacade1.PopForDuration(_30mins);
            Assert.NotNull(event30min);
            Assert.Equal(_30mins, event30min.Duration);
            Assert.Equal(--countEvents, _eventListFacade1.EventCount);
        }

        [Fact]
        public void PopForDuration4()
        {
            _eventListFacade1 = new EventListFacade(new List<Event>());
            Event event30min = _eventListFacade1.PopForDuration(_30mins);
            Assert.Null(event30min);
        }

        [Fact]
        public void TracksRequiredToScheduleAfternoon()
        {
            int trackShortDurationMins = 360;
            int trackLongDurationMins = 420;
            int shortTracksRequired = _eventListFacade1.TracksRequiredToSchedule(trackShortDurationMins);
            int longTracksRequired = _eventListFacade1.TracksRequiredToSchedule(trackLongDurationMins);
            Assert.True(shortTracksRequired >= longTracksRequired);
        }

        [Fact]
        public void DurationEventDictionary()
        {
            var dictionary1 = _eventListFacade1.DurationEventDictionary;
            int eventCountDict1 = dictionary1.Values.ToList().Sum(queue => queue.Count);
            Assert.Equal(_eventListFacade1.EventCount, eventCountDict1);
            foreach (int count in dictionary1.Keys)
            {
                Assert.Equal(_eventListFacade1.CountForDuration(count), dictionary1[count].Count);
            }

            foreach(Event evnt in _eventListFacade1.Events)
            {
                Assert.Contains(evnt,dictionary1[evnt.DurationMins]);
            }

            _eventListFacade1.PopMaxDuration();
            _eventListFacade1.PopMaxDuration();

            var dictionary2 = _eventListFacade1.DurationEventDictionary;
            int eventCountDict2 = dictionary2.Values.ToList().Sum(queue => queue.Count);
            Assert.Equal(_eventListFacade1.EventCount, eventCountDict2);
            foreach (int count in dictionary2.Keys)
            {
                Assert.Equal(_eventListFacade1.CountForDuration(count), dictionary2[count].Count);
            }

            foreach (Event evnt in _eventListFacade1.Events)
            {
                Assert.Contains(evnt, dictionary2[evnt.DurationMins]);
            }
        }

        [Fact]
        public void MaxDurationForCeiling()
        {
            Assert.Equal(_5mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 5, 0)));
            Assert.Equal(_5mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 14, 0)));

            Assert.Equal(_30mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 30, 0)));
            Assert.Equal(_30mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 44, 0)));

            Assert.Equal(_45mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 45, 0)));
            Assert.Equal(_45mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 59, 0)));

            Assert.Equal(_60mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 60, 0)));
            Assert.Equal(_60mins, _eventListFacade1.MaxDurationForAvailable(new TimeSpan(0, 100, 0)));

            EventListFacade eventListFacade = new(new List<Event>() { });
            Assert.Equal(_0mins, eventListFacade.MaxDurationForAvailable(new TimeSpan(0, 5, 0)));

            eventListFacade = new EventListFacade(new List<Event>() { _event30min });
            Assert.Equal(_0mins, eventListFacade.MaxDurationForAvailable(new TimeSpan(0, 5, 0)));
        }

        [Fact]
        public void MaxDurationForCeilingMins()
        {
            Assert.Equal(_5, _eventListFacade1.MaxDurationForCeilingMins(5));
            Assert.Equal(_5, _eventListFacade1.MaxDurationForCeilingMins(14));

            Assert.Equal(_30, _eventListFacade1.MaxDurationForCeilingMins(30));
            Assert.Equal(_30, _eventListFacade1.MaxDurationForCeilingMins(44));

            Assert.Equal(_45, _eventListFacade1.MaxDurationForCeilingMins(45));
            Assert.Equal(_45, _eventListFacade1.MaxDurationForCeilingMins(59));

            Assert.Equal(_60, _eventListFacade1.MaxDurationForCeilingMins(60));
            Assert.Equal(_60, _eventListFacade1.MaxDurationForCeilingMins(100));

            EventListFacade eventListFacade = new(new List<Event>() { });
            Assert.Equal(_0, eventListFacade.MaxDurationForCeilingMins(5));

            eventListFacade = new EventListFacade(new List<Event>() { _event30min });
            Assert.Equal(_0, eventListFacade.MaxDurationForCeilingMins(5));
        }
    }
}
