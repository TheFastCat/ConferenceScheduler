using System;
using Xunit;
using Whitespace;
using System.Globalization;

namespace WhitespaceTest
{
    public class SessionTests : TestBase
    {
        [Fact]
        public void MorningSessionConstructor()
        {
            Session session = new(DateTime.Now.Date.AddHours(9), DateTime.Now.Date.AddHours(12));
            Assert.Equal("9:00 AM", session.StartTimeString);
            Assert.Equal("12:00 PM", session.EndTimeString);
            Assert.Equal(DateTime.Today.AddHours(9), session.StartTime);
            Assert.Equal(DateTime.Today.AddHours(12), session.EndTime);
            Assert.Equal(_180mins, session.AvailableCapacity);
        }

        [Fact]
        public void AfternoonSessionConstructor()
        {
            Session sessionLong = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(17));
            Assert.Equal(DateTime.Today.AddHours(13), sessionLong.StartTime);
            Assert.Equal(DateTime.Today.AddHours(17), sessionLong.EndTime);
            Assert.Equal("1:00 PM", sessionLong.StartTimeString);
            Assert.Equal("5:00 PM", sessionLong.EndTimeString);
            Assert.Equal(_240mins, sessionLong.AvailableCapacity);

            Session sessionShort = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(16));
            Assert.Equal(DateTime.Today.AddHours(13), sessionShort.StartTime);
            Assert.Equal(DateTime.Today.AddHours(16), sessionShort.EndTime);
            Assert.Equal("1:00 PM", sessionShort.StartTimeString);
            Assert.Equal("4:00 PM", sessionShort.EndTimeString);
            Assert.Equal(_180mins, sessionShort.AvailableCapacity);
        }

        [Fact]
        public void CanScheduleEvent()
        {
            Assert.True(_morningSession.CanScheduleEvent(_eventLightning));
            Assert.True(_morningSession.CanScheduleEvent(_event15min));
            Assert.True(_morningSession.CanScheduleEvent(_event30min));
            Assert.True(_morningSession.CanScheduleEvent(_event45min));
            Assert.True(_morningSession.CanScheduleEvent(_event60min));
            Assert.True(_morningSession.CanScheduleEvent(_event180min));
            Assert.False(_morningSession.CanScheduleEvent(_event240min));

            Session sessionB = new(DateTime.Now.Date.AddHours(13), DateTime.Now.Date.AddHours(17));
            Assert.True(sessionB.CanScheduleEvent(_event240min));
            Assert.False(sessionB.CanScheduleEvent(_event241min));
        }

        [Fact]
        public void AvailableDuration()
        {
            Assert.Equal(_180mins, _morningSession.AvailableCapacity);
            Assert.Equal(_240mins, _afternoonSessionLong.AvailableCapacity);
            Assert.Equal(_180mins, _afternoonSessionShort.AvailableCapacity);
        }

        [Fact]
        public void AvailableDurationMins()
        {
            Assert.Equal(_180, _morningSession.AvailableCapactiyMins);
            Assert.Equal(_240, _afternoonSessionLong.AvailableCapactiyMins);
            Assert.Equal(_180, _afternoonSessionShort.AvailableCapactiyMins);
        }

        [Fact]
        public void ScheduledDuration()
        {
            Assert.Equal(_0mins, _morningSession.ScheduledCapacity);
            Assert.Equal(_0mins, _afternoonSessionLong.ScheduledCapacity);
            Assert.Equal(_0mins, _afternoonSessionShort.ScheduledCapacity);

            _morningSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5mins, _morningSession.ScheduledCapacity);

            _afternoonSessionLong.ScheduleEvent(_event15min);
            Assert.Equal(_15mins, _afternoonSessionLong.ScheduledCapacity);

            _afternoonSessionShort.ScheduleEvent(_event30min);
            Assert.Equal(_30mins, _afternoonSessionShort.ScheduledCapacity);
        }

        [Fact]
        public void ScheduledDurationMins()
        {
            Assert.Equal(_0, _morningSession.ScheduledCapacityMins);
            Assert.Equal(_0, _afternoonSessionLong.ScheduledCapacityMins);
            Assert.Equal(_0, _afternoonSessionShort.ScheduledCapacityMins);

            _morningSession.ScheduleEvent(_eventLightning);
            Assert.Equal(_5, _morningSession.ScheduledCapacityMins);

            _afternoonSessionLong.ScheduleEvent(_event15min);
            Assert.Equal(_15, _afternoonSessionLong.ScheduledCapacityMins);

            _afternoonSessionShort.ScheduleEvent(_event30min);
            Assert.Equal(_30, _afternoonSessionShort.ScheduledCapacityMins);
        }

        [Fact]
        public void ScheduleEvent1()
        {
            Assert.True(_morningSession.ScheduleEvent(_event60min));         
            Assert.Single(_morningSession.ScheduledEvents);
            Assert.Contains(_event60min, _morningSession.ScheduledEvents);
            Assert.Equal(_120mins, _morningSession.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event60min));          
            Assert.Single(_afternoonSessionLong.ScheduledEvents);
            Assert.Contains(_event60min, _afternoonSessionLong.ScheduledEvents);
            Assert.Equal(_180mins, _afternoonSessionLong.AvailableCapacity);
        }

        [Fact]
        public void ScheduleEvent2()
        {
            Assert.True(_morningSession.ScheduleEvent(_event60min));
            Assert.Single(_morningSession.ScheduledEvents);
            Assert.Contains(_event60min, _morningSession.ScheduledEvents);
            Assert.Equal(_120mins, _morningSession.AvailableCapacity);

            Assert.True(_morningSession.ScheduleEvent(_event60min));
            Assert.Equal(2, _morningSession.ScheduledEvents.Count);
            Assert.Equal(_60mins, _morningSession.AvailableCapacity);

            Assert.True(_morningSession.ScheduleEvent(_event60min));
            Assert.Equal(3, _morningSession.ScheduledEvents.Count);
            Assert.Equal(_0mins, _morningSession.AvailableCapacity);

            Assert.False(_morningSession.ScheduleEvent(_event1min));
            Assert.Equal(3, _morningSession.ScheduledEvents.Count);
            Assert.Equal(_0mins, _morningSession.AvailableCapacity);
        }

        [Fact]
        public void ScheduleEvent3()
        {
            Assert.True(_afternoonSessionLong.ScheduleEvent(_event15min));
            Assert.Single(_afternoonSessionLong.ScheduledEvents);
            Assert.Equal(new TimeSpan(0, 225, 0), _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event15min));
            Assert.Equal(2, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(new TimeSpan(0, 210, 0), _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event15min));
            Assert.Equal(3, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(new TimeSpan(0, 195, 0), _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event15min));
            Assert.Equal(4, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(_180mins, _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event120min));
            Assert.Equal(5, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(_60mins, _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_eventLightning));
            Assert.Equal(6, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(new TimeSpan(0, 55, 0), _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_eventLightning));
            Assert.Equal(7, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(new TimeSpan(0, 50, 0), _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_eventLightning));
            Assert.Equal(8, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(_45mins, _afternoonSessionLong.AvailableCapacity);

            Assert.True(_afternoonSessionLong.ScheduleEvent(_event45min));
            Assert.Equal(9, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(_0mins, _afternoonSessionLong.AvailableCapacity);

            Assert.False(_afternoonSessionLong.ScheduleEvent(_event45min));
            Assert.Equal(9, _afternoonSessionLong.ScheduledEvents.Count);
            Assert.Equal(_0mins, _afternoonSessionLong.AvailableCapacity);
        }

        [Fact]
        public void ForceEventScheduleAtTime()
        {
            int morningEventCount   = _morningSessionFilled.ScheduledEvents.Count;
            int afternoonEventCount = _afternoonSessionFilled.ScheduledEvents.Count;

            Assert.Equal(_0mins, _morningSessionFilled.AvailableCapacity);
            Assert.Equal(_0mins, _afternoonSessionFilled.AvailableCapacity);

            Event lunch      = new("Lunch 60min");
            lunch.StartTime = DateTime.Today.AddHours(12);
            Event networking = new("NetworkingEvent 60min");

            Assert.False(_morningSessionFilled.CanScheduleEvent(lunch));
            Assert.False(_morningSessionFilled.CanScheduleEvent(networking));

            Assert.False(_morningSessionFilled.ScheduleEvent(lunch));
            Assert.False(_morningSessionFilled.ScheduleEvent(networking));

            Assert.Equal(morningEventCount, _morningSessionFilled.ScheduledEvents.Count);
            Assert.Equal(afternoonEventCount, _afternoonSessionFilled.ScheduledEvents.Count);

            Assert.DoesNotContain(lunch, _morningSessionFilled.ScheduledEvents);
            Assert.DoesNotContain(networking, _afternoonSessionFilled.ScheduledEvents);

            Assert.True(_morningSessionFilled.ForceEventScheduleAtTime(lunch, true));/**/
            Assert.True(_afternoonSessionFilled.ForceEventScheduleAtTime(networking, false));/**/

            Assert.Equal(++morningEventCount, _morningSessionFilled.ScheduledEvents.Count);
            Assert.Equal(++afternoonEventCount, _afternoonSessionFilled.ScheduledEvents.Count);

            Assert.Contains(lunch, _morningSessionFilled.ScheduledEvents);
            Assert.Contains(networking, _afternoonSessionFilled.ScheduledEvents);
        }

        [Fact]
        public void ScheduleEventIgnoreConstraints()
        {
            Assert.False(_morningSessionFilled.CanScheduleEvent(_event1min));
            Assert.False(_morningSessionFilled.ScheduleEvent(_event1min));
            Assert.DoesNotContain(_event1min, _morningSessionFilled.ScheduledEvents);
            Assert.True(_morningSessionFilled.ScheduleEvent(_event1min, true));
            Assert.Contains(_event1min, _morningSessionFilled.ScheduledEvents);
        }
    }
}
