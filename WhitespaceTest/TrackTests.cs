using System;
using System.Collections.Generic;
using Xunit;
using Whitespace;
using System.Linq;

namespace WhitespaceTest
{
    public class TrackTests : TestBase
    {
        [Fact]
        public void Constructor()
        {
            Track trackLong = new(_sessionFactory, "Track1", _morningStartTime, _morningEndTime,_afternoonStartTime, _afternoonEndTime);
            Assert.NotNull(trackLong);
            Assert.Equal("Track1", trackLong.Identifier);
            Assert.Equal(_morningStartTime, trackLong.MorningSession.StartTime);
            Assert.Equal(_morningEndTime, trackLong.MorningSession.EndTime);
            Assert.Equal(_afternoonStartTime, trackLong.AfternoonSession.StartTime);
            Assert.Equal(_afternoonEndTime, trackLong.AfternoonSession.EndTime);
            Assert.Equal(_morningEndTime.Subtract(_morningStartTime), trackLong.MorningAvailableCapacity);
            Assert.Equal(_afternoonEndTime.Subtract(_afternoonStartTime), trackLong.AfternoonAvailableCapacity);
            Assert.Equal(_0mins, trackLong.ScheduledCapacity); 

            Track trackShort = new(_sessionFactory, "Track2", _morningStartTime, _morningEndTime, _afternoonStartTime, _afternoonEndTimeEarly);
            Assert.NotNull(trackShort);
            Assert.Equal("Track2", trackShort.Identifier);
            Assert.Equal(_morningStartTime, trackShort.MorningSession.StartTime);
            Assert.Equal(_morningEndTime, trackShort.MorningSession.EndTime);
            Assert.Equal(_afternoonStartTime, trackShort.AfternoonSession.StartTime);
            Assert.Equal(_afternoonEndTimeEarly, trackShort.AfternoonSession.EndTime);
            Assert.Equal(_morningEndTime.Subtract(_morningStartTime), trackShort.MorningAvailableCapacity);
            Assert.Equal(_afternoonEndTimeEarly.Subtract(_afternoonStartTime), trackShort.AfternoonAvailableCapacity);
            Assert.Equal(_0mins, trackShort.ScheduledCapacity); 
        }

        [Fact]
        public void Morning()
        {
            Assert.NotNull(_trackLong.MorningSession);
            Assert.NotNull(_trackShort.MorningSession);
        }
        
        [Fact]
        public void Afternoon()
        {
            Assert.NotNull(_trackLong.AfternoonSession);
            Assert.NotNull(_trackShort.AfternoonSession);
        }

        [Fact]
        public void MorningAvailableCapacity()
        {
            Assert.Equal(new TimeSpan(3, 0, 0), _trackLong.MorningAvailableCapacity);
            Assert.Equal(new TimeSpan(3, 0, 0), _trackShort.MorningAvailableCapacity);
        }

        [Fact]
        public void MorningAvailableCapacityMins()
        {
            Assert.Equal(new TimeSpan(3, 0, 0).TotalMinutes, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(new TimeSpan(3, 0, 0).TotalMinutes, _trackShort.MorningAvailableCapacityMins);
        }

        [Fact]
        public void AfternoonAvailableCapacity()
        {
            Assert.Equal(new TimeSpan(4, 0, 0), _trackLong.AfternoonAvailableCapacity);
            Assert.Equal(new TimeSpan(3, 0, 0), _trackShort.AfternoonAvailableCapacity);
        }

        [Fact]
        public void AfternoonAvailableCapacityMins()
        {
            Assert.Equal(new TimeSpan(4, 0, 0).TotalMinutes, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(new TimeSpan(3, 0, 0).TotalMinutes, _trackShort.AfternoonAvailableCapacityMins);
        }

        [Fact]
        public void AvailableCapacity()
        {
            Assert.Equal(new TimeSpan(7, 0, 0), _trackLong.AvailableCapacity);
            Assert.Equal(new TimeSpan(6, 0, 0), _trackShort.AvailableCapacity);
        }

        [Fact]
        public void AvailableCapacityMins()
        {
            Assert.Equal(new TimeSpan(7, 0, 0).TotalMinutes, _trackLong.AvailableCapacityMins);
            Assert.Equal(new TimeSpan(6, 0, 0).TotalMinutes, _trackShort.AvailableCapacityMins);
        }

        [Fact]
        public void MaxAvailableCapacity()
        {
            Assert.Equal(new TimeSpan(4, 0, 0), _trackLong.MaxAvailableCapacity);
            Assert.Equal(new TimeSpan(3, 0, 0), _trackShort.MaxAvailableCapacity);
        }

        [Fact]
        public void MaxAvailableCapacityMins()
        {
            Assert.Equal(_240, _trackLong.MaxAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.MaxAvailableCapacityMins);
        }

        [Fact]
        public void MorningScheduledCapacity()
        {
            Assert.Equal(_0mins, _trackLong.MorningScheduledCapacity);
            _trackLong.MorningSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5mins, _trackLong.MorningScheduledCapacity);
            _trackLong.MorningSession.ScheduleEvent(_event60min);
            Assert.Equal(_5mins + _60mins, _trackLong.MorningScheduledCapacity);
        }

        [Fact]
        public void MorningScheduledCapacityMins()
        {
            Assert.Equal(_0, _trackLong.MorningScheduledCapacityMins);
            _trackLong.MorningSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5, _trackLong.MorningScheduledCapacityMins);
            _trackLong.MorningSession.ScheduleEvent(_event60min);
            Assert.Equal(_5 + _60, _trackLong.MorningScheduledCapacityMins);
        }

        [Fact]
        public void AfternoonScheduledCapacity()
        {
            Assert.Equal(_0mins, _trackLong.AfternoonScheduledCapacity);
            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5mins, _trackLong.AfternoonScheduledCapacity);
            _trackLong.AfternoonSession.ScheduleEvent(_event60min);
            Assert.Equal(_5mins + _60mins, _trackLong.AfternoonScheduledCapacity);
        }

        [Fact]
        public void AfternoonScheduledCapacityMins()
        {
            Assert.Equal(_0, _trackLong.AfternoonScheduledCapacityMins);
            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5, _trackLong.AfternoonScheduledCapacityMins);
            _trackLong.AfternoonSession.ScheduleEvent(_event60min);
            Assert.Equal(_5 + _60, _trackLong.AfternoonScheduledCapacityMins);
        }

        [Fact]
        public void ScheduledCapacity()
        {
            Assert.Equal(_0mins, _trackLong.MorningSession.ScheduledCapacity);
            Assert.Equal(_0mins, _trackLong.AfternoonSession.ScheduledCapacity);

            _trackLong.MorningSession.ScheduleEvent(_eventLightning);
            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);

            Assert.Equal(_5mins + _5mins, _trackLong.ScheduledCapacity);

            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);

            Assert.Equal(_5mins + _5mins + _5mins, _trackLong.ScheduledCapacity);
        }

        [Fact]
        public void ScheduledDurationMins()
        {
            Assert.Equal(_0, _trackLong.MorningSession.ScheduledCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonSession.ScheduledCapacityMins);

            _trackLong.MorningSession.ScheduleEvent(_eventLightning);
            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);

            Assert.Equal(_5 + _5, _trackLong.ScheduledCapacityMins);

            _trackLong.AfternoonSession.ScheduleEvent(_eventLightning);

            Assert.Equal(_5 + _5 + _5, _trackLong.ScheduledCapacityMins);
        }

        [Fact]
        public void ScheduleMorningEvent()
        {
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_420, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleMorningEvent(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Contains(_event60min, _trackLong.MorningSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleMorningEvent(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleMorningEvent(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleMorningEvent(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleAfternoonEvent()
        {
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleAfternoonEvent(_event60min));
            Assert.Single(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Contains(_event60min, _trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleAfternoonEvent(_event60min));
            Assert.Equal(2, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleAfternoonEvent(_event60min));
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AvailableCapacityMins);

            Assert.False(_trackShort.ScheduleAfternoonEvent(_event60min));
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventMostCapacityOrMorningFirst()
        {
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_420, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Equal(2,_trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventLeastCapacityMorningFirst()
        {
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_420, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(2,_trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(3,_trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2,_trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventLeastCapacityMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleEventMostCapacityOrMorningFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventMorningFirst()
        {
            Assert.Empty(_trackShort.MorningSession.ScheduledEvents);
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Single(_trackShort.MorningSession.ScheduledEvents);
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(2, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_60, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(3, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(3, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Single(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(3, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AvailableCapacityMins);

            Assert.False(_trackShort.ScheduleEventMorningFirst(_event60min));
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventAfternoonFirst()
        {
            Assert.Empty(_trackShort.MorningSession.ScheduledEvents);
            Assert.Empty(_trackShort.AfternoonSession.ScheduledEvents);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Empty(_trackShort.MorningSession.ScheduledEvents);
            Assert.Single(_trackShort.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Empty(_trackShort.MorningSession.ScheduledEvents);
            Assert.Equal(2, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Empty(_trackShort.MorningSession.ScheduledEvents);
            Assert.Equal(3,_trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_180, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Single(_trackShort.MorningSession.ScheduledEvents);
            Assert.Equal(3,_trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_120, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Equal(2,_trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackShort.AvailableCapacityMins);

            Assert.True(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Equal(3, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AvailableCapacityMins);

            Assert.False(_trackShort.ScheduleEventAfternoonFirst(_event60min));
            Assert.Equal(3, _trackShort.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackShort.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackShort.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackShort.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventBalancedCountFirst()
        {
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_420, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleEventBalancedCountFirst(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(4, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_0, _trackLong.AvailableCapacityMins);
        }

        [Fact]
        public void ScheduleEventBalancedCount()
        {
            Assert.Empty(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_180, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_420, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Empty(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_360, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Single(_trackLong.MorningSession.ScheduledEvents);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_120, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_300, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Single(_trackLong.AfternoonSession.ScheduledEvents);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_240, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(2, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_60, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_180, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(2, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_120, _trackLong.AvailableCapacityMins);

            Assert.True(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);

            Assert.False(_trackLong.ScheduleEventBalancedCount(_event60min));
            Assert.Equal(3, _trackLong.MorningSession.ScheduledEvents.Count);
            Assert.Equal(3, _trackLong.AfternoonSession.ScheduledEvents.Count);
            Assert.Equal(_0, _trackLong.MorningAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AfternoonAvailableCapacityMins);
            Assert.Equal(_60, _trackLong.AvailableCapacityMins);
        }
    }
}
